Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmPurchaseOrder
    Dim EDIT_MODE As String = ""
    Dim ORDER_STAT As String = ""
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
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
    Private Sub createDocument(doc As Document)
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
        documentTitle.AddText("Local Purchase Order")
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
        paragraph.AddFormattedText("To:          " + cmbSupplier.Text, TextFormat.Bold)
        paragraph.Format.Font.Size = 9
        Dim supplier As New Supplier
        supplier.search((New Supplier).getSupplierCode("", cmbSupplier.Text))
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText(supplier.GL_ADDRESS)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Phone: " + supplier.GL_TELEPHONE)
        paragraph.Format.Font.Size = 8
        If supplier.GL_FAX <> "" Then
            paragraph = section.AddParagraph()
            paragraph.AddFormattedText("Fax: " + supplier.GL_FAX)
            paragraph.Format.Font.Size = 8
        End If
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Email: " + supplier.GL_EMAIL)
        paragraph.Format.Font.Size = 8
        paragraph.Format.Font.Italic = True
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Order#:      " + txtOrderNo.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Order Date:  " + txtOrderDate.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Valid Up To: " + txtVaildUntil.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Supplier#:   " + ((New Supplier).getSupplierCode("", cmbSupplier.Text)) + " " + cmbSupplier.Text)
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

        column = table.AddColumn("3cm")
        column.Format.Alignment = ParagraphAlignment.Center


        column = table.AddColumn("9cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        'row.Shading.Color = TableBlue
        row.Cells(0).AddParagraph("Code")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Description")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Pack Size")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Qty")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left

        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalQty As Double = 0

        For i As Integer = 0 To dtgrdItemList.RowCount - 1
            Dim code As String = dtgrdItemList.Item(1, i).Value.ToString
            Dim descr As String = dtgrdItemList.Item(2, i).Value.ToString
            Dim packing As String = dtgrdItemList.Item(3, i).Value.ToString
            Dim qty As String = dtgrdItemList.Item(4, i).Value.ToString
            totalQty = totalQty + Val(qty)
            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(code)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(descr)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(packing)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(qty)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left

            table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Next
        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = False
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Total Qty")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph(totalQty.ToString)
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left

        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Function lock()
        txtSupplierCode.ReadOnly = True
        cmbSupplier.Enabled = False
        Return vbNull
    End Function
    Private Function unlock()
        txtSupplierCode.ReadOnly = False
        cmbSupplier.Enabled = True
        Return vbNull
    End Function
    Private Function clear()
        txtOrderNo.Text = ""
        txtSupplierCode.Text = ""
        cmbSupplier.SelectedItem = Nothing
        cmbSupplier.Text = ""
        txtOrderDate.Text = ""
        txtVaildUntil.Text = ""
        txtOrderStatus.Text = ""
        cmbValidityPeriod.SelectedItem = Nothing
        cmbValidityPeriod.Text = ""
        txtTotal.Text = ""
        dtgrdItemList.Rows.Clear()

        Return vbNull
    End Function
    Private Function isSupply(itemCode As String, supplierCode As String) As Boolean
        Dim supply As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT  `supplier_id`, `item_code` FROM `supplier_item` WHERE `supplier_id`='" + (New Supplier).getSupplierID(supplierCode, "") + "' AND `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                supply = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return supply
    End Function
    Private Function searchSupplier() As Boolean
        Dim found As Boolean = False
        Dim supplier As New Supplier
        If txtSupplierCode.Text <> "" Then
            cmbSupplier.Text = supplier.getSupplierName("", txtSupplierCode.Text)
        ElseIf cmbSupplier.Text <> "" Then
            txtSupplierCode.Text = supplier.getSupplierCode("", cmbSupplier.Text)
        End If
        If supplier.getSupplierID(txtSupplierCode.Text, "") <> "" Then
            found = True
            lock()
        End If
        Return found
    End Function
    Private Function searchOrder(orderNo As String) As Boolean
        Dim found As Boolean = False
        Dim order As New Order
        If order.getOrder(orderNo) = True Then
            txtOrderNo.ReadOnly = True
            'txtOrderNo.Text = order.GL_ORDER_NO
            txtSupplierCode.Text = order.GL_SUPPLIER_CODE
            cmbSupplier.Text = (New Supplier).getSupplierName("", order.GL_SUPPLIER_CODE)
            txtOrderDate.Text = order.GL_ORDER_DATE
            txtOrderStatus.Text = order.GL_STATUS
            cmbValidityPeriod.Text = order.GL_VALIDITY_PERIOD
            txtVaildUntil.Text = order.GL_VALID_UNTIL

            lock()
        End If
        Return found
    End Function
    Private Function search()
        If txtOrderNo.Text = "" Then
            MsgBox("Can not process order. Please specify whether the order is new or existing by selecting New or Edit", vbOKOnly + vbCritical, "Invalid operation")
            Return vbNull
            Exit Function
        End If
        If txtOrderNo.ReadOnly = False Then
            Dim order As New Order
            If order.getOrder(txtOrderNo.Text) = True Then
                txtOrderNo.ReadOnly = True
                'txtOrderNo.Text = order.GL_ORDER_NO
                txtSupplierCode.Text = order.GL_SUPPLIER_CODE
                cmbSupplier.Text = (New Supplier).getSupplierName("", order.GL_SUPPLIER_CODE)
                txtOrderDate.Text = order.GL_ORDER_DATE
                txtOrderStatus.Text = order.GL_STATUS
                cmbValidityPeriod.Text = order.GL_VALIDITY_PERIOD
                txtVaildUntil.Text = order.GL_VALID_UNTIL
                lock()
                refreshList()

                'End If
                'If searchOrder(txtOrderNo.Text) = True Then
                EDIT_MODE = ""
                'txtOrderNo.ReadOnly = True
                lock()
                Dim status As String = order.GL_STATUS

                If status = "APPROVED" Or status = "PRINTED" Or status = "REPRINTED" Or status = "COMPLETED" Or status = "CANCELED" Then
                    btnApprove.Enabled = False
                Else
                    btnApprove.Enabled = True
                End If

            Else
                MsgBox("No matching order", vbOKOnly + vbCritical, "Error: Not found")
                Return vbNull
                Exit Function
            End If
        End If
        If searchSupplier() = True Then
            If EDIT_MODE = "NEW" Then
                txtOrderStatus.Text = "NEW"
            End If
            btnSave.Enabled = True
        Else
            If txtSupplierCode.Text = "" Then
                MsgBox("Please enter supplier code", vbOKOnly + vbCritical, "Error: Missing information")
            Else
                MsgBox("No matching supplier", vbOKOnly + vbCritical, "Error: Not found")
            End If
        End If
        Return vbNull
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        clear()
        cmbValidityPeriod.Text = "30"
        txtVaildUntil.Text = ((New Day).getCurrentDay.AddDays(Val(cmbValidityPeriod.Text))).ToString("yyyy-MM-dd")
        EDIT_MODE = "NEW"
        ORDER_STAT = "NEW"
        txtOrderNo.ReadOnly = True
        txtSupplierCode.ReadOnly = False
        cmbSupplier.Enabled = True
        txtOrderStatus.Text = ""
        txtOrderDate.Text = Day.DAY
        unlock()
        btnSave.Enabled = False
        txtOrderNo.Text = (New Order).generateOrderNo
        If txtOrderNo.Text = "" Then
            txtOrderNo.Text = "0"
        End If
        dtgrdItemList.Rows.Clear()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If User.authorize("EDIT LPO") = True Then

        Else
            MsgBox("Action denied for current user.", vbOKOnly + vbExclamation, "Action denied")
            Exit Sub
        End If
        If txtOrderStatus.Text = "NEW" Then
            txtOrderStatus.Text = ""
        End If
        EDIT_MODE = ""
        ORDER_STAT = ""
        txtOrderNo.ReadOnly = False
        lock()
        clear()
    End Sub




    Private Function saveNewOrder() As String
        Dim ordNo As String = ""
        Try
            Dim order As New Order
            order.GL_ORDER_NO = txtOrderNo.Text
            order.GL_ORDER_DATE = txtOrderDate.Text
            order.GL_VALIDITY_PERIOD = cmbValidityPeriod.Text
            order.GL_VALID_UNTIL = txtVaildUntil.Text
            order.GL_SUPPLIER_ID = (New Supplier).getSupplierID(txtSupplierCode.Text, "")
            order.GL_STATUS = "PENDING"
            order.GL_USER_ID = User.CURRENT_USER_ID
            order.addNewOrder()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function

    Private Function saveOrderDetail(orderNo As String, itemCode As String, qty As Double, unitCostPrice As Double, stockSize As Double) As Boolean
        Dim success As Boolean = False
        Try
            Dim order As New Order
            order.GL_ORDER_NO = orderNo
            order.GL_ITEM_CODE = itemCode
            order.GL_QUANTITY = qty
            order.GL_UNIT_COST_PRICE = unitCostPrice
            order.GL_STOCK_SIZE = stockSize
            order.addOrderDetails()
            success = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        refreshList()
        If cmbValidityPeriod.Text = "" Then
            MsgBox("Please select validity period!", vbOKOnly + vbExclamation, "Error: Missing information")
            Exit Sub
        End If
        If dtgrdItemList.RowCount > 0 Then
            Dim order As New Order
            'update the fields
            order.GL_ORDER_DATE = txtOrderDate.Text
            order.GL_VALIDITY_PERIOD = cmbValidityPeriod.Text
            order.GL_VALID_UNTIL = txtVaildUntil.Text
            order.GL_STATUS = "PENDING"
            order.GL_USER_ID = User.CURRENT_USER_ID
            order.editOrder(txtOrderNo.Text)
            MsgBox("Order saved.", vbOKOnly + vbInformation, "Success")
        Else
            Dim res As Integer = MsgBox("No items are listed in this order. Would you like to save an empty order?", vbYesNo + vbQuestion, "Save empty order?")
            If res = DialogResult.Yes Then
                If (New Order).isOrderExist(txtOrderNo.Text) = False Then

                    Dim order As New Order
                    order.GL_ORDER_NO = txtOrderNo.Text
                    order.GL_ORDER_DATE = txtOrderDate.Text
                    order.GL_VALIDITY_PERIOD = cmbValidityPeriod.Text
                    order.GL_VALID_UNTIL = txtVaildUntil.Text
                    order.GL_SUPPLIER_ID = (New Supplier).getSupplierID(txtSupplierCode.Text, "")
                    order.GL_STATUS = "BLANK"
                    order.GL_USER_ID = User.CURRENT_USER_ID
                    txtOrderNo.Text = order.addNewOrder()

                    'If saveNewOrder() = True Then
                    EDIT_MODE = ""
                    'btnSave.Enabled = False
                    'End If
                Else
                    Dim order As New Order
                    'update the fields
                    order.GL_ORDER_DATE = txtOrderDate.Text
                    order.GL_VALIDITY_PERIOD = cmbValidityPeriod.Text
                    order.GL_VALID_UNTIL = txtVaildUntil.Text
                    order.GL_STATUS = "BLANK"
                    order.GL_USER_ID = User.CURRENT_USER_ID
                    order.editOrder(txtOrderNo.Text)
                    'btnSave.Enabled = False
                End If
            End If
        End If

    End Sub
    Private Function refreshList()
        dtgrdItemList.Rows.Clear()
        Try

            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `sn`, `order_no`, `item_code`, `quantity`, `unit_cost_price`, `stock_size` FROM `order_details` WHERE `order_no`='" + txtOrderNo.Text + "' "
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim sn As String = ""
            Dim barCode As String = ""
            Dim itemCode As String = ""
            Dim description As String = ""
            Dim quantity As String = ""
            Dim packSize As String = ""
            Dim costPrice As String = ""
            Dim stockSize As String = ""
            Dim totalCost As Double = 0

            Dim total As Double = 0

            While reader.Read
                Dim item As New Item
                itemCode = reader.GetString("item_code")
                item.searchItem(itemCode)
                sn = reader.GetString("sn")
                description = item.GL_LONG_DESCR
                quantity = reader.GetString("quantity")
                packSize = item.GL_PCK
                costPrice = reader.GetString("unit_cost_price")
                stockSize = reader.GetString("stock_size")
                totalCost = Val(quantity) * Val(costPrice)

                total = total + Val(quantity) * Val(costPrice)

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = barCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = itemCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = description
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = packSize
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = quantity
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(costPrice)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(totalCost.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = stockSize
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = sn
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdItemList.Rows.Add(dtgrdRow)
            End While
            txtTotal.Text = LCurrency.displayValue(total)
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function

    Private Sub dtgrdItemList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdItemList.CellContentClick

    End Sub

    Private Sub dtgrdItemList_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdItemList.RowHeaderMouseDoubleClick

        Dim status As String = (New Order).getStatus(txtOrderNo.Text)
        If status = "APPROVED" Then
            MsgBox("You can not edit this order. Order already approved.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "PRINTED" Then
            MsgBox("You can not edit this order. Order already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "REPRINTED" Then
            MsgBox("You can not edit this order. Order already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("You can not edit this order. Order already completed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("You can not edit this order. Order canceled.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If


        Dim row As Integer = -1
        row = dtgrdItemList.CurrentRow.Index

        Dim barCode As String = dtgrdItemList.Item(0, row).Value
        Dim itemCode As String = dtgrdItemList.Item(1, row).Value
        Dim description As String = dtgrdItemList.Item(2, row).Value
        Dim packSize As String = dtgrdItemList.Item(3, row).Value
        Dim quantity As String = dtgrdItemList.Item(4, row).Value
        Dim costPrice As String = dtgrdItemList.Item(5, row).Value
        Dim totalCost As String = dtgrdItemList.Item(6, row).Value
        Dim stockSize As String = dtgrdItemList.Item(7, row).Value
        Dim sn As String = dtgrdItemList.Item(8, row).Value

        Dim dtgrdRow As New DataGridViewRow

        txtItemCodeS.Text = itemCode
        cmbDescription.Text = description
        txtQuantity.Text = quantity
        txtPackSize.Text = packSize
        txtCostPrice.Text = costPrice
        txtStockSize.Text = stockSize

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `order_details` WHERE `sn`='" + sn + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            lockFields()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        refreshList()

    End Sub

    Dim longSupplier As New List(Of String)
    Dim shortSupplier As New List(Of String)
    Private Sub frmPurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        clearFields()

        txtOrderNo.Text = ""
        txtSupplierCode.Text = ""
        cmbSupplier.SelectedItem = Nothing
        cmbSupplier.Text = ""
        txtOrderDate.Text = ""
        cmbValidityPeriod.Text = ""
        txtOrderStatus.Text = ""
        txtVaildUntil.Text = ""
        txtSupplierCode.ReadOnly = True
        cmbSupplier.Enabled = False

        Dim supplier As New Supplier
        longSupplier = supplier.getSuppliers("")
        refreshLPOList()

    End Sub
    Private Sub refreshLPOList()
        dtgrdLPOList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `order_id`, `order_no`, `order_date`, `validity_period`, `valid_until`, `supplier_id`, `status`, `user_id` FROM `orders` WHERE `status`='BLANK' OR `status`='PENDING' OR `status`='APPROVED' OR `status`='PRINTED' OR `status`='REPRINTED' OR `status`='COMPLETED'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim issueNo As String = ""
            Dim issueDate As String = ""
            Dim status As String = ""
            Dim salesPerson As String = ""

            While reader.Read
                Dim item As New Item
                issueNo = reader.GetString("order_no")
                issueDate = reader.GetString("order_date")
                status = reader.GetString("status")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = issueNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = issueDate
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = status
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdLPOList.Rows.Add(dtgrdRow)

            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmPurchaseOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtOrderNo.Text = ""
        dtgrdItemList.Rows.Clear()

        Dim item As New Item
        longList = item.getItems()

    End Sub

    Private Sub cmbValidityPeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbValidityPeriod.SelectedIndexChanged
        If EDIT_MODE = "" Then
            Exit Sub
        End If
        Dim validityPeriod As Integer = Val(cmbValidityPeriod.Text)
        If validityPeriod > 0 And validityPeriod <= 60 Then
            txtVaildUntil.Text = ((New Day).getCurrentDay.AddDays(validityPeriod)).ToString("yyyy-MM-dd")
        Else
            txtVaildUntil.Text = ""
        End If
    End Sub

    Private Sub txtSupplierCode_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtSupplierCode.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If txtOrderNo.Text = "" Then
            MsgBox("Please select an order to delete.", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If
        Dim order As New Order
        If order.isOrderExist(txtOrderNo.Text) <> True Then
            MsgBox("No matching order", vbOKOnly + vbExclamation, "")
            Exit Sub
        End If
        search()
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected order: " + txtOrderNo.Text + " ? Information on this order will be removed from the system.", vbYesNo + vbQuestion, "Delete order?")
        If res = DialogResult.Yes Then
            order.deleteOrder(txtOrderNo.Text)
            MsgBox("Order Successively removed", vbOKOnly + vbInformation, "")
        End If
    End Sub

    Private Sub txtOrderDate_TextChanged(sender As Object, e As EventArgs) Handles txtOrderDate.TextChanged

    End Sub



    Private Sub txtOrderNo_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtOrderNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search()
        End If
    End Sub

    Private Sub btnSearchItem_Click(sender As Object, e As EventArgs) Handles btnSearchItem.Click
        If txtSupplierCode.Text = "" Then
            MsgBox("Please select Supplier", vbOKOnly + vbCritical, "Error: No supplier")
            Exit Sub
        End If
        Dim found As Boolean = False
        Dim valid As Boolean = False
        Dim barCode As String = txtBarCode.Text
        Dim itemCode As String = txtItemCodeS.Text
        Dim descr As String = cmbDescription.Text

        If barCode <> "" Then
            itemCode = (New Item).getItemCode(barCode, "")
        ElseIf itemCode <> "" Then
            itemCode = itemCode
        ElseIf descr <> "" Then
            itemCode = (New Item).getItemCode("", descr)
        Else
            itemCode = ""
        End If

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `item_code`, `item_long_description`, `pck`,`unit_cost_price`, `retail_price`,`vat`, `margin`, `standard_uom`, `active` FROM `items` WHERE `item_code`='" + itemCode + "' AND `supplier_id`='" + (New Supplier).getSupplierID(txtSupplierCode.Text, "") + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtItemCodeS.Text = reader.GetString("item_code")
                cmbDescription.Text = reader.GetString("item_long_description")
                txtPackSize.Text = reader.GetString("pck")
                txtCostPrice.Text = reader.GetString("unit_cost_price")
                txtStockSize.Text = (New Inventory).getInventory(reader.GetString("item_code"))
                found = True
                'If isSupply(txtItemCodeS.Text, txtSupplierCode.Text) <> True Then
                'MsgBox("Can not add item to this order. Item not available for this Supplier")
                'clearFields()
                'Else
                valid = True
                lockFields()
                txtQuantity.ReadOnly = False
                'End If
                Exit While
            End While
            conn.Close()
            If found = False Then
                MsgBox("Item not available for this supplier", vbOKOnly + vbCritical, "Item not found")
                clearFields()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub clearFields()
        txtBarCode.Text = ""
        txtItemCodeS.Text = ""
        cmbDescription.SelectedItem = Nothing
        cmbDescription.Text = ""
        txtPackSize.Text = ""
        txtQuantity.Text = ""
        txtCostPrice.Text = ""
        txtStockSize.Text = ""
    End Sub
    Private Sub lockFields()
        txtBarCode.ReadOnly = True
        txtItemCodeS.ReadOnly = True
        cmbDescription.Enabled = False

        btnAdd.Enabled = True
    End Sub
    Private Sub unLockFields()
        txtBarCode.ReadOnly = False
        txtItemCodeS.ReadOnly = False
        cmbDescription.Enabled = True

        btnAdd.Enabled = False
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim status As String = (New Order).getStatus(txtOrderNo.Text)
        If status = "APPROVED" Then
            MsgBox("You can not edit this order. Order already approved.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "PRINTED" Then
            MsgBox("You can not edit this order. Order already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "REPRINTED" Then
            MsgBox("You can not edit this order. Order already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("You can not edit this order. Order already completed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("You can not edit this order. Order canceled.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        Dim barCode As String = txtBarCode.Text
        Dim itemCode As String = txtItemCodeS.Text
        Dim descr As String = cmbDescription.Text
        Dim qty As String = txtQuantity.Text
        Dim costPrice As String = txtCostPrice.Text
        Dim stockSize As String = txtStockSize.Text
        If itemCode = "" Then
            MsgBox("Invalid entry")
            Exit Sub
        End If
        If Val(qty) <= 0 Then
            MsgBox("Could not add item. Invalid quantity entry. Quantity should not be negative", vbOKOnly + vbCritical, "Error: Invalid entry")
            Exit Sub
        End If
        If Val(qty) Mod 1 <> 0 Then
            ' MsgBox("Could not add item. Invalid quantity entry. Quantity should be a whole number", vbOKOnly + vbCritical, "Error: Invalid entry")
            ' Exit Sub
        End If
        Dim order As Order
        If ORDER_STAT = "NEW" Then
            order = New Order
            order.GL_ORDER_NO = txtOrderNo.Text
            Dim orderDate As String = (New Day).getCurrentDay.ToString("yyyy-MM-dd")
            order.GL_ORDER_DATE = orderDate
            order.GL_VALIDITY_PERIOD = cmbValidityPeriod.Text
            Dim validityPeriod As Integer = Val(cmbValidityPeriod.Text)

            If validityPeriod > 0 And validityPeriod < 60 Then
                txtVaildUntil.Text = ((New Day).getCurrentDay.AddDays(validityPeriod)).ToString("yyyy-MM-dd")
            End If
            order.GL_VALID_UNTIL = txtVaildUntil.Text
            order.GL_SUPPLIER_ID = (New Supplier).getSupplierID(txtSupplierCode.Text, "")
            order.GL_STATUS = "PENDING"
            order.GL_USER_ID = User.CURRENT_USER_ID
            txtOrderNo.Text = (New Order).generateOrderNo
            If order.isOrderExist(txtOrderNo.Text) = False Then
                If order.addNewOrder() = True Then
                    ORDER_STAT = ""
                End If
            Else
                ORDER_STAT = ""
            End If
        End If
        order = New Order
        order.GL_ORDER_NO = txtOrderNo.Text
        order.GL_ITEM_CODE = itemCode
        order.GL_QUANTITY = Val(qty)
        order.GL_UNIT_COST_PRICE = Val(LCurrency.getValue(costPrice))
        order.GL_STOCK_SIZE = Val(stockSize)
        order.addOrderDetails()
        refreshList()

        clearFields()
        unLockFields()
        Exit Sub
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        clearFields()
        unLockFields()
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim status As String = (New Order).getStatus(txtOrderNo.Text)
        If status = "APPROVED" Then
            MsgBox("You can not approve this order. Order already approved.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "PRINTED" Then
            MsgBox("You can not approve this order. Order already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "REPRINTED" Then
            MsgBox("You can not approve this order. Order already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("You can not approve this order. Order already completed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("You can not approve this order. Order canceled.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "BLANK" Then
            MsgBox("Could not approve a blank LPO", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If User.authorize("APPROVE LPO") = True Then
            If txtOrderNo.Text = "" Then
                MsgBox("Please select order to approve", vbOKOnly + vbInformation, "")
                Exit Sub
            End If
            Dim res As Integer = MsgBox("Are you sure you want to approve the selected order : " + txtOrderNo.Text + " ? Once approved, you will no longer be able to edit the selected order.", vbYesNo + vbQuestion, "Approve order?")
            If res = DialogResult.Yes Then
                'approve order

                If dtgrdItemList.RowCount = 0 Then
                    MsgBox("You can not approve an empty order", vbOKOnly + vbInformation, "")
                    Exit Sub
                End If
                Dim order As Order = New Order
                If order.approveOrder(txtOrderNo.Text) = True Then
                    MsgBox("Order Successively approved", vbOKOnly + vbInformation, "")
                    txtOrderNo.ReadOnly = False
                    search()
                Else
                    MsgBox("Could not approve order", vbOKOnly + vbInformation, "")
                End If
            End If
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub txtOrderNo_TextChanged(sender As Object, e As EventArgs) Handles txtOrderNo.TextChanged
        If txtOrderNo.Text = "" Then
            btnApprove.Enabled = False
        Else
            btnApprove.Enabled = True
        End If
    End Sub

    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)
    Private Sub cmbDescription_KeyUp(sender As Object, e As EventArgs) Handles cmbDescription.KeyUp
        Dim currentText As String = cmbDescription.Text
        shortList.Clear()
        cmbDescription.Items.Clear()
        cmbDescription.Items.Add(currentText)
        cmbDescription.DroppedDown = True
        For Each text As String In longList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbDescription.Text.ToUpper()) Then
                shortList.Add(text)
            End If
        Next
        cmbDescription.Items.AddRange(shortList.ToArray())
        cmbDescription.SelectionStart = cmbDescription.Text.Length
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmbSupplier_KeyUp(sender As Object, e As EventArgs) Handles cmbSupplier.KeyUp
        Dim currentText As String = cmbSupplier.Text
        shortSupplier.Clear()
        cmbSupplier.Items.Clear()
        cmbSupplier.Items.Add(currentText)
        cmbSupplier.DroppedDown = True
        For Each text As String In longSupplier
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbSupplier.Text.ToUpper()) Then
                shortSupplier.Add(text)
            End If
        Next
        cmbSupplier.Items.AddRange(shortSupplier.ToArray())
        cmbSupplier.SelectionStart = cmbSupplier.Text.Length
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub dtgrdLPOList_CellContentClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdLPOList.RowHeaderMouseClick
        Dim r As Integer = dtgrdLPOList.CurrentRow.Index
        Dim lpoNo As String = dtgrdLPOList.Item(0, r).Value.ToString
        txtOrderNo.Text = lpoNo
        txtOrderNo.ReadOnly = False
        search()
    End Sub

    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click
        Dim status As String = (New Order).getStatus(txtOrderNo.Text)
        If Not status = "COMPLETED" Then
            MsgBox("Only COMPLETED LPO can be archived", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        '     If User.authorize("APPROVE LPO") = True Then
        If txtOrderNo.Text = "" Then
            MsgBox("Please select order to archive", vbOKOnly + vbInformation, "")
            Exit Sub
        End If

        'approve order


        Dim order As Order = New Order
        If order.archiveOrder(txtOrderNo.Text) = True Then
            txtOrderNo.ReadOnly = False
            search()
            refreshLPOList()
        Else
            MsgBox("Could not approve order", vbOKOnly + vbInformation, "")
        End If


        '   Else
        'MsgBox("Access denied!", vbOKOnly + vbExclamation)
        ' End If
    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim status As String = (New Order).getStatus(txtOrderNo.Text)
        If Not (status = "PENDING" Or status = "BLANK") Then
            MsgBox("Only a PENDING or BLANK LPO can be canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        '     If User.authorize("APPROVE LPO") = True Then
        If txtOrderNo.Text = "" Then
            MsgBox("Please select order to cancel", vbOKOnly + vbInformation, "")
            Exit Sub
        End If

        'approve order
        Dim res As Integer = MsgBox("Are you sure you want to cancel the selected order : " + txtOrderNo.Text + " ? After canceling, the order will be rendered invalid", vbYesNo + vbQuestion, "Approve order?")

        status = (New Order).getStatus(txtOrderNo.Text)
        If res = DialogResult.Yes And (status = "PENDING" Or status = "BLANK") Then
            Dim order As Order = New Order
            If order.cancelOrder(txtOrderNo.Text) = True Then
                txtOrderNo.ReadOnly = False
                search()
                refreshLPOList()
            Else
                MsgBox("Could not cancel order", vbOKOnly + vbInformation, "")
            End If
        End If



        '   Else
        'MsgBox("Access denied!", vbOKOnly + vbExclamation)
        ' End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If txtOrderNo.Text = "" Then
            MsgBox("Select order to print.", vbOKOnly + vbCritical, "Error:No selection")
            Exit Sub
        End If
        Dim status As String = (New Order).getStatus(txtOrderNo.Text)
        If status = "PRINTED" Or status = "REPRINTED" Then
            Dim res As Integer = MsgBox("This order has already been printed. Would you like to re-print it?", vbYesNo + vbQuestion, "Reprint order?")
            If res = DialogResult.Yes Then
                'continue
            Else
                Exit Sub
            End If
        End If
        If status = "PENDING" Or status = "NEW" Or status = "CANCELLED" Or status = "CANCELED" Or status = "BLANK" Then
            MsgBox("Could not print order. Order has not been approved", vbOKOnly, "Invalid operation")
            Exit Sub
        End If
        If status = "" Then
            MsgBox("Could not print order. Order status unknown", vbOKOnly, "Invalid operation")
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not print order. Order already completed", vbOKOnly, "Invalid operation")
            Exit Sub
        End If

        Dim document As Document = New Document

        document.Info.Title = "Local Purchase Order"
        document.Info.Subject = "Local Purchase Order"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\" & txtOrderNo.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)
        Dim order As New Order
        If status = "PRINTED" Or status = "REPRINTED" Then
            order.changeStatus(txtOrderNo.Text, "REPRINTED")
        Else
            order.changeStatus(txtOrderNo.Text, "PRINTED")
        End If
        refreshLPOList()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
        clearFields()
    End Sub

    Private Sub btnArchiveAll_Click(sender As Object, e As EventArgs) Handles btnArchiveAll.Click
        clear()
        clearFields()
        Dim res As Integer = MsgBox("Are you sure you want to archive all completed LPO documents? All completed documents will be sent to archives for future reference.", vbQuestion + vbYesNo, "Archive all cleared packing lists")
        If res = DialogResult.Yes Then
            Dim noOfdocuments As Integer = 0
            Try
                Cursor = Cursors.WaitCursor
                For i As Integer = 0 To dtgrdLPOList.RowCount - 1
                    Dim no As String = dtgrdLPOList.Item(0, i).Value.ToString
                    Dim list As Order = New Order
                    Dim status As String = list.getStatus(no)
                    If status = "COMPLETED" Then
                        noOfdocuments = noOfdocuments + 1
                    End If
                Next
                If noOfdocuments = 0 Then
                    MsgBox("No documents to archive, only completed documents can be arcived", vbOKOnly + vbExclamation, "No documents to archive")
                    Cursor = Cursors.Default
                    Exit Sub
                Else
                    Dim confirm As Integer = MsgBox(noOfdocuments.ToString + " documents will be archived, continue?", vbYesNo + vbQuestion, "Concirm archive")
                    If Not confirm = DialogResult.Yes Then
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                MsgBox("Could not archive")
                Cursor = Cursors.Default
                Exit Sub
            End Try

            Try
                Cursor = Cursors.WaitCursor
                For i As Integer = 0 To dtgrdLPOList.RowCount - 1
                    Dim no As String = dtgrdLPOList.Item(0, i).Value.ToString
                    Dim list As Order = New Order
                    Dim status As String = list.getStatus(no)
                    If status = "COMPLETED" Then
                        'archive
                        list.archiveOrder(no)
                    End If
                Next
                MsgBox(noOfdocuments.ToString + " document(s) archived successifuly")
            Catch ex As Exception
                '  MsgBox(ex.ToString)
            End Try
            refreshLPOList()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub txtTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotal.TextChanged

    End Sub
End Class