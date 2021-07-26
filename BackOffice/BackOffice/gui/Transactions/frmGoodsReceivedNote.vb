﻿Imports System.IO
Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmGoodsReceivedNote

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Function SearchOrder(orderNo As String)
        Dim found As Boolean = False
        Dim order As New Order
        If txtOrderNo.Text = "" Then
            MsgBox("Enter order number !", vbOKOnly + vbExclamation, "Error: Missing information")
            Return found
            Exit Function
        End If
        If order.getOrder(orderNo) = True Then
            Dim orderStatus As String = order.GL_STATUS
            If orderStatus = "PRINTED" Or orderStatus = "REPRINTED" Then
                'proceed

            Else
                If orderStatus = "PENDING" Or orderStatus = "APPROVED" Then
                    MsgBox("Goods can not be received. This order have not been printed!", vbOKOnly + vbCritical, "Error: Order not printed")
                ElseIf orderStatus = "COMPLETED" Then
                    MsgBox("Order already completed!", vbOKOnly + vbExclamation, "Error: Completed order")
                ElseIf orderStatus = "CANCELLED" Then
                    MsgBox("Order cancelled!", vbOKOnly + vbExclamation, "Error: Cancelled order")
                Else
                    MsgBox("Order not available!", vbOKOnly + vbExclamation, "Error: Not available")
                End If
                Return found
                Exit Function

            End If
            txtOrderNo.Text = order.GL_ORDER_NO
            txtSupplier.Text = (New Supplier).getSupplierName("", order.GL_SUPPLIER_CODE)
            txtSupplierCode.Text = order.GL_SUPPLIER_CODE
            found = True
            txtOrderNo.ReadOnly = True
        Else
            MsgBox("No matching order", vbOKOnly + vbCritical, "Error: Not found")
        End If
        Return found
    End Function
    Private Function getOrderDetails(orderNo As String) As Boolean
        Dim success As Boolean = False
        If txtOrderNo.Text = "" Then
            MsgBox("Enter order number!", vbOKOnly + vbExclamation, "Error: Missing information")
            Return success
            Exit Function
        End If
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `sn`, `order_no`, `item_code`, `quantity`, `unit_cost_price`, `stock_size` FROM `order_details` WHERE `order_no`='" + orderNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Dim itemCode As String = reader.GetString("item_code")
                Dim description As String = (New Item).getItemLongDescription(itemCode)
                Dim orderedQty As String = reader.GetString("quantity")
                Dim receivedQty As String = ""
                Dim supplierCost As String = ""
                Dim clientCost As String = reader.GetString("unit_cost_price")
                Dim sn As String = reader.GetString("sn")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = itemCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = description
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = orderedQty
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = receivedQty
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = supplierCost
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = clientCost
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = "NO"
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = sn
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdItemList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Dim orderNo As String = ""
    Private Function getOrder(order_No As String) As Boolean
        dtgrdItemList.Rows.Clear()
        txtSupplier.Text = ""
        If SearchOrder(order_No) = True Then
            orderNo = order_No
            If getOrderDetails(order_No) = True Then

            End If
        Else
            orderNo = ""
        End If
        Return vbNull
    End Function
    Private Function search()
        If txtOrderNo.Text = "" Then
            txtOrderNo.ReadOnly = False
            Return vbNull
            Exit Function
        End If
        getOrder(txtOrderNo.Text)
        Return vbNull
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub

    Private Sub dtgrdItemList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdItemList.CellContentClick

    End Sub
    Private Function checkCost(supplierCost As Double, clientCost As Double) As Boolean
        Dim lessOrEqual As Boolean = True
        If (supplierCost - clientCost) > 0 Then
            lessOrEqual = False
        End If
        Return lessOrEqual
    End Function
    Private Function checkQuantity(suppliedQty As Double, orderedQty As Double) As Boolean
        Dim lessOrEqual As Boolean = True
        If suppliedQty - orderedQty > 0 Then
            lessOrEqual = False
        End If
        Return lessOrEqual
    End Function
    Private Function received(hasReceived As Boolean)
        If hasReceived = True Then
            dtgrdItemList.Item(6, dtgrdItemList.CurrentCell.RowIndex).Value = "YES"
        Else
            dtgrdItemList.Item(6, dtgrdItemList.CurrentCell.RowIndex).Value = "NO"
        End If
        refreshList()
        Return vbNull
    End Function
    Private Sub dtgrdItemList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdItemList.CellEndEdit

        Dim row As Integer = dtgrdItemList.CurrentCell.RowIndex
        Dim col As Integer = dtgrdItemList.CurrentCell.ColumnIndex

        Dim orderedQty As Double = Val(dtgrdItemList.Item(2, row).Value)
        Dim suppliedQty As Double = Val(dtgrdItemList.Item(3, row).Value)
        Dim supplierCost As Double = Val(dtgrdItemList.Item(4, row).Value)
        Dim clientCost As Double = Val(dtgrdItemList.Item(5, row).Value)

        If dtgrdItemList.CurrentCell.ColumnIndex = 3 Then
            If Not IsNumeric(dtgrdItemList.CurrentCell.Value) Then
                MsgBox("Invalid value. Input should be numeric", vbOKOnly + vbCritical, "Invalid entry")
                dtgrdItemList.CurrentCell.Value = 0
            End If
            If checkQuantity(suppliedQty, orderedQty) <> True Then
                MsgBox("Quantity value rejected. Received quantity should not exceed quantity ordered", vbOKOnly + vbCritical, "Error: Invalid entry")
                dtgrdItemList.CurrentCell.Value = 0
                Exit Sub
            End If
        End If
        If dtgrdItemList.CurrentCell.ColumnIndex = 4 Then
            If Val(dtgrdItemList.Item(3, row).Value) = 0 Then
                MsgBox("Enter Quantity first!", vbOKOnly + vbExclamation, "Quantity required")
                dtgrdItemList.CurrentCell.Value = 0
                received(False)
                Exit Sub
            End If
            If Not IsNumeric(dtgrdItemList.CurrentCell.Value) Then
                MsgBox("Invalid value. Input should be numeric", vbOKOnly + vbCritical, "Error: Invalid entry")
                dtgrdItemList.CurrentCell.Value = 0
                received(False)
                Exit Sub
            End If
            If checkCost(supplierCost, clientCost) <> True Then
                MsgBox("Supplier Cost exceed by " + LCurrency.displayValue((supplierCost - clientCost).ToString) + " This value will be rejected", vbOKOnly + vbCritical, "Error: Excess value")
                dtgrdItemList.CurrentCell.Value = 0
                received(False)
                Exit Sub
            End If
            received(True)
        End If
    End Sub
    Private Function clear()
        dtgrdItemList.Rows.Clear()
        txtOrderNo.Text = ""
        txtSupplier.Text = ""
        Return vbNull
    End Function
    Private Sub frmGoodsReceivedNote_Load(sender As Object, e As EventArgs) Handles Me.Shown
        clear()
    End Sub
    Private Function confirmReceive() As Boolean
        Dim status As String = (New Order).getStatus(orderNo)
        Dim success As Boolean = False

        If status = "PRINTED" Or status = "REPRINTED" Then
            'continue
        Else
            MsgBox("Can not complete order. Order already completed/canceled or has not been printed", vbOKOnly, "Invalid operation")
            Return success
            Exit Function
        End If


        If dtgrdItemList.RowCount = 0 Then
                MsgBox("Enter order", vbOKOnly + vbExclamation, "Missing information")
                Return success
                Exit Function
            End If
            Dim res As Integer = MsgBox("Are you sure you want to complete this order?", vbYesNo + vbQuestion, "Complete Order?")
            If res = DialogResult.Yes Then
                'complete the order

            Else
                Return success
                Exit Function
            End If
            If validateList() = False Then
                'discard operation
                'MsgBox("There is an error in the List. Please cross check the list.", vbOKOnly + vbExclamation, "Error: List invalid")
                Return success
                Exit Function
            End If
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim codeQuery As String = "UPDATE `orders` SET `status`='COMPLETED' WHERE `order_no`='" + orderNo + "'"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                conn.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Dim supplierCost As Double = 0
            Dim clientCost As Double = 0
            Dim difference As Double = 0

            createGRN(txtOrderNo.Text, txtInvoiceNo.Text, Day.DAY, "")
            Dim grnNo As String = getGRNNo(txtOrderNo.Text, txtInvoiceNo.Text, Day.DAY, "")
            txtGRNNo.Text = grnNo
            Dim amount As Double = 0

            For i As Integer = 0 To dtgrdItemList.RowCount - 1
                Dim itemCode As String = dtgrdItemList.Item(0, i).Value
                Dim qtyReceived As String = dtgrdItemList.Item(3, i).Value
                Dim supplierUnitCost As Double = Val(dtgrdItemList.Item(4, i).Value)
                Dim clientUnitCost As Double = Val(dtgrdItemList.Item(5, i).Value)
                supplierCost = supplierCost + (supplierUnitCost * Val(qtyReceived))
                clientCost = clientCost + (clientUnitCost * Val(qtyReceived))
                If supplierCost > 0 Then
                    amount = supplierCost
                End If
                receiveGood(grnNo, itemCode, qtyReceived, supplierUnitCost.ToString) 'receive goods and update goods received note
            updateInventory(itemCode, qtyReceived, grnNo) ' update inventory of the particular item
        Next
            Dim ok As Integer = MsgBox("Operation successiful. Print GRN Note?", vbYesNo + vbInformation, "Success: Received goods") 'to implement grn print functionality
            If ok = DialogResult.Yes Then
                printGRN(grnNo, txtOrderNo.Text, txtInvoiceNo.Text, txtSupplierCode.Text, txtDate.Text, LCurrency.displayValue(amount.ToString))
            End If
            clear()
        Return vbNull
    End Function
    Private Sub defineStyles(doc As Document)
        'Get the predefined style Normal.
        Dim style As Style = doc.Styles("Normal")
        'Because all styles are derived from Normal, the next line changes the
        'font of the whole document. Or, more exactly, it changes the font of
        'all styles And paragraphs that do Not redefine the font.
        style.Font.Name = "Verdana"
        'style = doc.Document.Styles(StyleNames.Header)
        style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right)
        style = doc.Styles(StyleNames.Footer)
        style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center)
        'Create a new style called Table based on style Normal
        style = doc.Styles.AddStyle("Table", "Normal")
        style.Font.Name = "Verdana"
        style.Font.Name = "Calibri"
        style.Font.Size = 10
        'Create a new style called Reference based on style Normal
        style = doc.Styles.AddStyle("Reference", "Normal")
        style.ParagraphFormat.SpaceBefore = "5mm"
        style.ParagraphFormat.SpaceAfter = "5mm"
        style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right)

    End Sub
    Private Function printGRN(grnNo As String, orderNo As String, invoiceNo As String, supplierCode As String, date_ As String, grnAmount As String)

        Dim document As Document = New Document

        document.Info.Title = "GRN"
        document.Info.Subject = "GRN"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document, grnNo, orderNo, invoiceNo, supplierCode, date_, grnAmount)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\GRN" & grnNo & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)


        Return vbNull
    End Function
    Private Sub createDocument(doc As Document, grnNo As String, orderNo As String, invoiceNo As String, supplierCode As String, date_ As String, grnAmount As String)
        'Each MigraDoc document needs at least one section.
        Dim section As Section = doc.AddSection()
        section.PageSetup.DifferentFirstPageHeaderFooter = True
        Dim paragraph As Paragraph
        doc.FootnoteStartingNumber() = 1
        paragraph = section.Footers.Primary.AddParagraph()
        Dim _datetime As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        paragraph.AddText("Printed :" & _datetime + " By :" & User.CURRENT_ALIAS & " From :" & Company.NAME)
        paragraph.Format.Font.Size = 8
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Color = Colors.GreenYellow
        paragraph = section.Footers.Primary.AddParagraph()
        paragraph.AddPageField()
        paragraph.AddText(" of ")
        paragraph.AddNumPagesField()
        paragraph.Format.Alignment = ParagraphAlignment.Right
        section.Footers.FirstPage = section.Footers.Primary.Clone()
        'Start of header
        Dim logoPath As String = ""
        Dim logoImage As Image = Nothing
        Dim headerTable As Table = section.Headers.FirstPage.AddTable()
        headerTable.Borders.Width = 0.2
        headerTable.Borders.Left.Width = 0.2
        headerTable.Borders.Right.Width = 0.2
        headerTable.Rows.LeftIndent = 0
        Dim headerColumn As Column
        headerColumn = headerTable.AddColumn("2.2cm")
        headerColumn.Format.Alignment = ParagraphAlignment.Left
        headerColumn = headerTable.AddColumn("0.3cm")
        headerColumn.Format.Alignment = ParagraphAlignment.Left
        headerColumn = headerTable.AddColumn("12cm")
        headerColumn.Format.Alignment = ParagraphAlignment.Left
        Dim headerRow As Row
        headerRow = headerTable.AddRow()
        headerRow.Format.Font.Bold = False
        headerRow.HeadingFormat = True
        headerRow.Format.Font.Size = 9
        headerRow.Format.Alignment = ParagraphAlignment.Center
        headerRow.Borders.Color = Colors.White
        Try
            Dim logo As New System.IO.MemoryStream(CType(Company.LOGO, Byte()))
            logoImage = Image.FromStream(logo)
            logoPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "TempDocumentLogo.png"
            If My.Computer.FileSystem.FileExists(logoPath) Then
                My.Computer.FileSystem.DeleteFile(logoPath)
            End If
            logoImage.Save(logoPath)
            If logo.Length > 0 Then
                headerRow.Cells(0).AddImage(logoPath).Width = "2.2cm"
                headerRow.Cells(0).Format.Alignment = ParagraphAlignment.Left
            End If
        Catch ex As Exception
        End Try
        headerRow.Cells(1).AddParagraph("")
        Dim companyName As New Paragraph
        companyName.AddText(Company.NAME + Environment.NewLine)
        companyName.Format.Font.Bold = True
        companyName.Format.Font.Size = 9
        Dim physicalAddress As New Paragraph
        physicalAddress.AddText(Company.PHYSICAL_ADDRESS + Environment.NewLine)
        physicalAddress.Format.Font.Size = 8
        Dim address As New Paragraph
        address.AddText(Company.ADDRESS + Environment.NewLine)
        address.Format.Font.Size = 8
        Dim postCode As New Paragraph
        postCode.AddText(Company.POST_CODE + Environment.NewLine)
        postCode.Format.Font.Size = 8
        Dim telephone As New Paragraph
        telephone.AddText("Tel: " + Company.TELEPHONE + " Mob:" + Company.MOBILE + Environment.NewLine)
        telephone.Format.Font.Size = 7
        Dim email As New Paragraph
        email.AddText("Email: " + Company.EMAIL + Environment.NewLine)
        email.Format.Font.Size = 7
        email.Format.Font.Italic = True
        headerRow.Cells(2).Add(companyName)
        headerRow.Cells(2).Add(physicalAddress)
        headerRow.Cells(2).Add(postCode)
        headerRow.Cells(2).Add(address)
        headerRow.Cells(2).Add(telephone)
        headerRow.Cells(2).Add(email)
        headerRow.Cells(2).Format.Alignment = ParagraphAlignment.Left
        headerTable.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        Dim tittleTable As Tables.Table = section.AddTable()
        tittleTable.Borders.Width = 0.25
        tittleTable.Borders.Left.Width = 0.5
        tittleTable.Borders.Right.Width = 0.5
        tittleTable.Rows.LeftIndent = 0
        Dim titleColumn As Tables.Column
        titleColumn = tittleTable.AddColumn("2.5cm")
        titleColumn.Format.Alignment = ParagraphAlignment.Left
        titleColumn = tittleTable.AddColumn("12.0cm")
        titleColumn.Format.Alignment = ParagraphAlignment.Left
        Dim titleRow As Tables.Row
        Dim documentTitle As New Paragraph
        documentTitle.AddText("Goods Received Note")
        documentTitle.Format.Alignment = ParagraphAlignment.Left
        documentTitle.Format.Font.Size = 10
        documentTitle.Format.Font.Color = Colors.Black
        titleRow = tittleTable.AddRow()
        titleRow.Format.Font.Bold = True
        titleRow.HeadingFormat = True
        titleRow.Format.Font.Size = 8
        titleRow.Format.Alignment = ParagraphAlignment.Center
        titleRow.Format.Font.Bold = True
        titleRow.Borders.Color = Colors.White
        titleRow.Cells(0).AddParagraph("")
        titleRow.Cells(0).Format.Alignment = ParagraphAlignment.Left
        titleRow.Cells(1).Add(documentTitle)
        titleRow.Cells(1).Format.Alignment = ParagraphAlignment.Left
        tittleTable.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        'end of header

        paragraph = section.AddParagraph()

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("GRN#:        " + grnNo)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Order#:      " + orderNo)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Invoice#:    " + invoiceNo)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Received on: " + date_)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Supplier#:   " + supplierCode)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Supplier:    " + (New Supplier).getSupplierName("", supplierCode))
        paragraph.Format.Font.Size = 8



        'Add the print date field
        paragraph = section.AddParagraph()
        paragraph.Format.SpaceBefore = "1cm"
        paragraph.Style = "Reference"
        paragraph.AddTab()
        paragraph.AddText("Created: ")
        paragraph.AddDateField("dd.MM.yyyy")

        'Create the item table
        Dim table As Table = section.AddTable()
        table.Style = "Table"
        ' table.Borders.Color = TableBorder
        table.Borders.Width = 0.25
        table.Borders.Left.Width = 0.5
        table.Borders.Right.Width = 0.5
        table.Rows.LeftIndent = 0

        'Before you can add a row, you must define the columns
        Dim column As Column

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Center


        column = table.AddColumn("8cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Code")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Description")

        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Qty")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Price@")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Center
        row.Cells(4).AddParagraph("Amount")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Center


        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0
        Dim totalQty As Double = 0

        For i As Integer = 0 To dtgrdItemList.RowCount - 1
            Dim code As String = dtgrdItemList.Item(0, i).Value
            Dim description As String = dtgrdItemList.Item(1, i).Value
            Dim qty As String = dtgrdItemList.Item(3, i).Value
            Dim price As String = dtgrdItemList.Item(4, i).Value
            Dim amount As String = (Val(price) * Val(qty))
            totalQty = totalQty + Val(qty)
            price = LCurrency.displayValue(price)
            amount = LCurrency.displayValue(amount)

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(code)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(description)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(qty)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(price)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Right
            row.Cells(4).AddParagraph(amount)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Right

            table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Next

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph()
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(4).AddParagraph()
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right


        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Total Qty")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(4).AddParagraph(totalQty)
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right


        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Total Amount")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(4).AddParagraph(grnAmount)
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right

        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

    End Sub
    Private Function validateList() As Boolean
        Dim valid As Boolean = False
        Dim emptyField As Boolean = False
        Dim atLeastOne As Integer = 0 'make sure at least one of the items in the order list have been received
        For i As Integer = 0 To dtgrdItemList.RowCount - 1
            Dim itemCode As String = dtgrdItemList.Item(0, i).Value
            Dim qtyReceived As String = dtgrdItemList.Item(3, i).Value
            Dim supplierUnitCost As Double = Val(dtgrdItemList.Item(4, i).Value)
            Dim clientUnitCost As Double = Val(dtgrdItemList.Item(5, i).Value)
            Dim received As String = dtgrdItemList.Item(6, i).Value
            If Val(qtyReceived) = 0 Then
                emptyField = True
            End If
            If received = "YES" Then
                atLeastOne = atLeastOne + 1
            End If
            If supplierUnitCost <> clientUnitCost And received = "YES" Then
                valid = False
            Else
                valid = True
            End If
        Next
        If atLeastOne <= 0 Then
            MsgBox("Operation failed. At least one item should be received.", vbOKOnly + vbExclamation, "Error: No item received")
            valid = False
            Return valid
            Exit Function
        End If
        If valid = False Then
            MsgBox("There is an error in the List. Please cross check the list for missing information.", vbOKOnly + vbExclamation, "Error: List invalid")
            Return valid
            Exit Function
        End If
        If emptyField = True Then
            Dim res As Integer = MsgBox("The list might be missing important information. Please cross check the list for missing quantity and cost values. Proceed anyway?", vbYesNo + vbQuestion, "Some information might be missing")
            If res = DialogResult.Yes Then
                valid = True
            Else
                valid = False
            End If
        End If
        Return valid
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnReceive.Click
        If orderNo <> "" Then
            If txtInvoiceNo.Text <> "" Then
                txtInvoiceNo.ReadOnly = True
                txtOrderNo.ReadOnly = True
                txtDate.Text = Day.DAY
                confirmReceive()
                clearFields()
                dtgrdItemList.Rows.Clear()
            Else
                MsgBox("Please enter invoice No!", vbOKOnly + vbExclamation, "Error: Missing information")
            End If
        End If
    End Sub
    Private Function updateInventory(itemCode As String, qty As String, grnNo As String)
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `inventorys` SET `qty`=`qty`+" + Val(qty).ToString + " WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            Dim inventory As New Inventory

            Dim stockCard As New StockCard
            stockCard.qtyIn(Day.DAY, itemCode, Val(qty), inventory.getInventory(itemCode), "Received goods, GRN No: " + grnNo)
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        Return vbNull
    End Function
    Private Function receiveGood(grnNo As String, itemCode As String, qty As String, costPrice As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `goods_received_note_particulars`(`grn_no`, `item_code`, `qty`, `unit_cost`) VALUES (@grn_no,@item_code,@qty,@unit_cost)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@grn_no", grnNo)
            command.Parameters.AddWithValue("@item_code", itemCode)
            command.Parameters.AddWithValue("@qty", qty)
            command.Parameters.AddWithValue("@unit_cost", costPrice)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Private Function getGRNNo(orderNo As String, invoiceNo As String, date_ As String, amount As String) As String
        Dim no As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `grn_no`, `order_no`, `invoice_no`, `grn_date`, `amount` FROM `goods_received_note` WHERE `order_no`='" + orderNo + "' AND `invoice_no`='" + invoiceNo + "' AND `grn_date`='" + date_ + "' ORDER BY `grn_no` DESC LIMIT 1"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                no = reader.GetString("grn_no")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return no
    End Function
    Private Function createGRN(orderNo As String, invoiceNo As String, date_ As String, amount As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `goods_received_note`( `order_no`, `invoice_no`, `grn_date`, `amount`) VALUES (@order_no, @invoice_no, @grn_date, @amount)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@order_no", orderNo)
            command.Parameters.AddWithValue("@invoice_no", invoiceNo)
            command.Parameters.AddWithValue("@grn_date", date_)
            command.Parameters.AddWithValue("@amount", amount)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return success
    End Function


    Private Sub txtOrderNo_PeviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtOrderNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search()
        End If
    End Sub
    Private Function refreshList()
        Dim total As Double = 0
        For i As Integer = 0 To dtgrdItemList.RowCount - 1
            If Val(dtgrdItemList.Item(3, i).Value) > 0 Then
                total = total + Val(LCurrency.getValue(dtgrdItemList.Item(4, i).Value)) * Val(dtgrdItemList.Item(3, i).Value)
            End If
        Next
        txtAmount.Text = LCurrency.displayValue(total.ToString)
        Return vbNull
    End Function
    Private Sub frmGoodsReceivedNote_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        clearFields()
        dtgrdItemList.Rows.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        dtgrdItemList.Rows.Clear()
        txtOrderNo.Text = ""
        orderNo = ""
        txtOrderNo.ReadOnly = False
        txtInvoiceNo.ReadOnly = False
        clearFields()
        dtgrdItemList.Rows.Clear()
    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearFields()
        dtgrdItemList.Rows.Clear()
    End Sub
    Private Sub clearFields()
        txtOrderNo.Text = ""
        orderNo = ""
        txtInvoiceNo.Text = ""
        txtGRNNo.Text = ""
        txtDate.Text = ""
        txtSupplierCode.Text = ""
        txtSupplier.Text = ""
        txtOrderNo.ReadOnly = False
        txtInvoiceNo.ReadOnly = False
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class