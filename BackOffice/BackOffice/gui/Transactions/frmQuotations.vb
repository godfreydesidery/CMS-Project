Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmQuotations

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

        documentTitle.AddText("Quotation")
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
        paragraph.AddFormattedText("Quotation No: " + txtInvoiceNo.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Quotation Date: " + txtIssueDate.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Status: " + (New SalesInvoice).getStatus(txtInvoiceNo.Text))
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Customer:       " + cmbCustomerName.Text)
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

        Dim status As String = (New Quotation).getStatus(txtInvoiceNo.Text)

        Dim skip As Integer = 0


        'Before you can add a row, you must define the columns
        Dim column As Column

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("6.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("1.0cm")
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
        row.Format.Font.Size = 9
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.Black
        row.Cells(0).AddParagraph("Item code")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Description")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Qty")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("@Price")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("Amount")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left


        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0



        For i As Integer = 0 To dtgrdItemList.RowCount - 1
            Dim code As String = dtgrdItemList.Item(2, i).Value.ToString
            Dim description As String = dtgrdItemList.Item(3, i).Value.ToString
            Dim price As String = dtgrdItemList.Item(6, i).Value.ToString
            Dim qty As String = dtgrdItemList.Item(4, i).Value.ToString
            Dim amount As String = dtgrdItemList.Item(7, i).Value.ToString

            skip = skip + 1

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 9
            row.Height = "6mm"
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.Black
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
        row.Format.Font.Bold = False
        row.HeadingFormat = False
        row.Format.Font.Size = 9
        row.Height = "6mm"
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph()
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph()
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph()
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Total")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph(txtTotal.Text)
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        paragraph = section.AddParagraph()


        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()

        paragraph = section.AddParagraph()
        paragraph.AddText("Issued by:________________Verified by:________________Approved by:________________")
        paragraph.Format.Font.Size = 8

    End Sub

    Private Function clear()
        txtInvoiceNo.Text = ""

        Return vbNull
    End Function


    Private Function searchQuotation(quotationNo As String) As Boolean
        Dim found As Boolean = False
        Dim list As New Quotation
        If list.getQuotation(quotationNo) = True Then
            txtInvoiceNo.ReadOnly = True
            'txtOrderNo.Text = order.GL_ORDER_NO

            txtIssueDate.Text = list.GL_QUOTATION_DATE
            txtStatus.Text = list.GL_STATUS
            cmbCustomerName.Text = list.GL_CUSTOMER_NAME


            'txtTotalSales.Text = LCurrency.displayValue((LCurrency.getValue(txtTotalAmountIssued.Text)).ToString)

        End If
        Return found
    End Function
    Private Function search()
        clearItemFields()
        If txtInvoiceNo.Text = "" Then
            MsgBox("Can not process quotation. Please specify whether the quotation is new or existing by selecting New or Edit", vbOKOnly + vbCritical, "Invalid operation")
            Return vbNull
            Exit Function
        End If
        If txtInvoiceNo.ReadOnly = False Then
            Dim list As New Quotation
            If list.getQuotation(txtInvoiceNo.Text) = True Then
                txtId.Text = list.GL_ID
                txtInvoiceNo.ReadOnly = True

                token = touch(txtInvoiceNo.Text)

                txtIssueDate.Text = list.GL_QUOTATION_DATE
                txtStatus.Text = list.GL_STATUS

                cmbCustomerName.Text = list.GL_CUSTOMER_NAME
                '   txtCustomerAddress.Text = list.GL_CUSTOMER_ADDRESS

                refreshList()
                If txtId.Text = "" Then
                    btnSave.Enabled = False
                Else
                    btnSave.Enabled = True
                End If

                Dim status As String = list.GL_STATUS

                If status = "NEW" Then
                    txtInvoiceNo.ReadOnly = True
                    cmbCustomerName.Enabled = True

                    txtBarCode.ReadOnly = False
                    txtItemCode.ReadOnly = False
                    cmbDescription.Enabled = True
                End If

            Else
                MsgBox("No matching record", vbOKOnly + vbCritical, "Error: Not found")
                Return vbNull
                Exit Function
            End If
        End If

        Return vbNull
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub
    Private Sub clearItemFields()
        txtBarCode.Text = ""
        txtItemCode.Text = ""
        cmbDescription.Text = ""
        txtPrice.Text = ""
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If User.authorize("CREATE & CANCEL PACKING LIST") = False Then
            '   MsgBox("Access Denied", vbOKOnly + vbExclamation, "Access denied")
            '  Exit Sub
        End If

        txtId.Text = ""
        txtInvoiceNo.Text = ""
        txtIssueDate.Text = ""
        txtStatus.Text = "NEW"

        cmbCustomerName.Text = ""
        '   txtCustomerAddress.Text = ""

        txtBarCode.Text = ""
        txtItemCode.Text = ""
        cmbDescription.Text = ""
        txtPrice.Text = ""
        txtQty.Text = ""

        txtInvoiceNo.ReadOnly = True


        txtBarCode.ReadOnly = False
        txtItemCode.ReadOnly = False
        cmbDescription.Enabled = True

        txtIssueDate.Text = Day.DAY
        btnSave.Enabled = False
        'clear()
        txtInvoiceNo.Text = (New Quotation).generateQuotationNo
        If txtInvoiceNo.Text = "" Then
            txtInvoiceNo.Text = "NAN"
        End If
        dtgrdItemList.Rows.Clear()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click



        ' If User.authorize("EDIT PACKING LIST") = True Then


        '  Else
        'MsgBox("Action denied for current user.", vbOKOnly + vbExclamation, "Action denied")
        'Exit Sub
        ' End If

        If txtId.Text = "" Then

            btnSave.Enabled = False
            txtInvoiceNo.ReadOnly = False
            txtInvoiceNo.Text = ""
            txtIssueDate.Text = ""
            txtStatus.Text = ""
        Else
            If User.authorize("CREATE & CANCEL PACKING LIST") = False Then
                '   MsgBox("Access Denied", vbOKOnly + vbExclamation, "Access denied")
                '   Exit Sub
            End If
            btnSave.Enabled = True
            txtInvoiceNo.ReadOnly = True
        End If

    End Sub


    Private Function saveQuotationDetail(quotationNo As String, itemCode As String, price As Double, qty As Double) As Boolean
        Dim success As Boolean = False
        Try
            Dim list As New Quotation
            list.GL_QUOTATION_NO = quotationNo
            list.GL_ITEM_CODE = itemCode
            list.GL_PRICE = price
            list.GL_QTY = qty
            list.addQuotationDetails()
            success = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return success
    End Function

    Private Function refreshList()
        Dim total As Double = 0
        Cursor = Cursors.WaitCursor
        dtgrdItemList.Rows.Clear()
        Try

            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT  `id`, `item_code`, `barcode`, `description`, `qty`, `price`, `quotation_no` FROM `quotation_details` WHERE `quotation_no`='" + txtInvoiceNo.Text + "' "
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim id As String = ""
            Dim barCode As String = ""
            Dim itemCode As String = ""
            Dim description As String = ""
            Dim price As Double = vbNull
            Dim qty As Double = vbNull


            While reader.Read
                Dim item As New Item
                itemCode = reader.GetString("item_code")
                id = reader.GetString("id")
                description = reader.GetString("description")
                price = Val(reader.GetString("price"))

                qty = Val(reader.GetString("qty"))

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = id
                dtgrdRow.Cells.Add(dtgrdCell)

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
                dtgrdCell.Value = qty
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)


                dtgrdCell = New DataGridViewTextBoxCell()
                ' dtgrdCell.Value = price
                dtgrdCell.Value = LCurrency.displayValue(price.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue((Val(qty) * Val(price)).ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdItemList.Rows.Add(dtgrdRow)

                total = total + (Val(qty) * Val(price))
            End While

            conn.Close()

            txtTotal.Text = LCurrency.displayValue(total.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            dtgrdItemList.CurrentCell = dtgrdItemList.Rows(currentRow).Cells(0)
            dtgrdItemList.Rows(currentRow).Selected = True
        Catch ex As Exception

        End Try

        Cursor = Cursors.Arrow
        Return vbNull
    End Function

    Private Sub dtgrdItemList_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdItemList.RowHeaderMouseClick
        txtPrice.ReadOnly = True
        Dim status As String = (New Quotation).getStatus(txtInvoiceNo.Text)
        If status = "PENDING" Or status = "PARTIAL" Or status = "PAID" Then
            '  MsgBox("Could not edit, invoice already posted", vbOKOnly + vbExclamation, "Error: Invalid operation")
            '  clearFields()
            '  Exit Sub
        End If
        If status = "ARCHIVED" Then
            MsgBox("Could not edit, quotation has been archived", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("Could not edit, quotation has been canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If

        Dim row As Integer = -1
        row = dtgrdItemList.CurrentRow.Index
        currentRow = row 'sets a row index ti be used in autoscroll

        'If dtgrdItemList.SelectedRows.Count = 1 Then
        'oldRow = row
        ' Else
        'oldRow = -1
        'End If

        'Dim barCode As String = dtgrdItemList.Item(0, row).Value
        Dim itemCode As String = dtgrdItemList.Item(2, row).Value
        Dim description As String = dtgrdItemList.Item(3, row).Value
        Dim price As String = dtgrdItemList.Item(6, row).Value
        Dim qty As String = dtgrdItemList.Item(4, row).Value
        Dim sn As String = dtgrdItemList.Item(1, row).Value

        Dim dtgrdRow As New DataGridViewRow

        txtItemCode.Text = itemCode
        cmbDescription.Text = description
        txtPrice.Text = price
        txtQty.Text = qty


        If status = "NEW" Then
            'lock
            txtBarCode.ReadOnly = True
            txtItemCode.ReadOnly = True
            cmbDescription.Enabled = False

            'unlock


            btnAdd.Enabled = True
        End If
        If status = "PENDING" Or status = "PARTIAL" Or status = "PAID" Then
            'lock
            '      txtBarCode.ReadOnly = True
            '    txtItemCode.ReadOnly = True
            '   cmbDescription.Enabled = False


            '   btnAdd.Enabled = False
        End If

    End Sub

    Dim oldRow As Integer = -1
    Dim glsn As String = ""

    Private Sub dtgrdItemList_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdItemList.RowHeaderMouseDoubleClick
        txtPrice.ReadOnly = True
        Dim status As String = (New SalesInvoice).getStatus(txtInvoiceNo.Text)

        Dim row As Integer = -1
        row = dtgrdItemList.CurrentRow.Index


        Dim sn As String = dtgrdItemList.Item(0, row).Value

        If check(txtInvoiceNo.Text, token) = False Then
            MsgBox("Could not modify document, the document has been modified by some one else. Please reload the document to continue", vbOKOnly + vbExclamation, "Invalid Operation")
            Cursor = Cursors.Default
            Exit Sub
        End If

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `quotation_details` WHERE `id`='" + sn + "'"
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
        clearItemdetails()
        refreshList()

    End Sub
    Private Sub loadCustomers()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            Dim suppcommand As New MySqlCommand()
            Dim supplierQuery As String = "SELECT `customer_id`, `customer_code`, `customer_name`, `address`, `post_code`, `physical_address`, `contact_name`, `bank_acc_name`, `bank_acc_address`, `bank_post_code`, `bank_name`, `bank_acc_no`, `telephone`, `mob`, `email`, `fax`, `tin`, `vrn`, `invoice_limit`, `credit_limit`, `status` FROM `corporate_customers` WHERE `status`='ACTIVE'"
            conn.Open()
            suppcommand.CommandText = supplierQuery
            suppcommand.Connection = conn
            suppcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = suppcommand.ExecuteReader
            cmbCustomerName.Items.Clear()
            If reader.HasRows Then
                While reader.Read
                    cmbCustomerName.Items.Add(reader.GetString("customer_name"))
                End While
            End If
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Dim longCustomerList As New List(Of String)
    Dim shortCustomerList As New List(Of String)

    Private Sub cmbCustomer_KeyUp(sender As Object, e As EventArgs) Handles cmbCustomerName.KeyUp

        Dim currentText As String = cmbCustomerName.Text
        shortCustomerList.Clear()
        cmbCustomerName.Items.Clear()
        cmbCustomerName.Items.Add(currentText)

        cmbCustomerName.DroppedDown = True
        For Each text As String In longCustomerList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbCustomerName.Text.ToUpper()) Then
                shortCustomerList.Add(text)
            End If
        Next
        cmbCustomerName.Items.AddRange(shortCustomerList.ToArray())
        cmbCustomerName.SelectionStart = cmbCustomerName.Text.Length
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub frmSalesInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.AppStarting
        resetAll()
        Dim customer As New CorporateCustomer
        longCustomerList = customer.getCustomers("")
        Dim item As New Item
        longList = item.getItems()
        refreshQuotationLists()
        Cursor = Cursors.Default
    End Sub

    Private Sub frmSalesInvoice_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtInvoiceNo.Text = ""
        dtgrdItemList.Rows.Clear()

    End Sub

    Private Sub txtOrderNo_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtInvoiceNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search()
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

    Private Sub btnSearchItem_Click(sender As Object, e As EventArgs) Handles btnSearchItem.Click

        Dim found As Boolean = False
        Dim valid As Boolean = False
        Dim barCode As String = txtBarCode.Text
        Dim itemCode As String = txtItemCode.Text
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
            Dim codeQuery As String = "SELECT `item_code`, `item_long_description`, `pck`,`unit_cost_price`, `retail_price`,`vat`, `margin`, `standard_uom`, `active`, `sellable` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                If reader.GetString("sellable") <> "1" Then
                    MsgBox("Item can not be sold", vbOKOnly + vbExclamation, "Item not sellable")
                    Exit Sub
                End If
                txtItemCode.Text = reader.GetString("item_code")
                cmbDescription.Text = reader.GetString("item_long_description")
                txtPrice.Text = LCurrency.displayValue(reader.GetString("retail_price"))
                found = True
                valid = True
                lockFields()
                Exit While
            End While
            conn.Close()
            If found = False Then
                MsgBox("Item not found", vbOKOnly + vbExclamation, "Error: Not found")
                clearFields()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub clearFields()
        txtBarCode.Text = ""
        txtItemCode.Text = ""
        cmbDescription.Text = ""
        txtQty.Text = ""
        txtPrice.Text = ""

    End Sub
    Private Sub lockFields()
        txtBarCode.ReadOnly = True
        txtItemCode.ReadOnly = True
        cmbDescription.Enabled = False

        btnAdd.Enabled = True
    End Sub
    Private Sub unLockFields()
        txtBarCode.ReadOnly = False
        txtItemCode.ReadOnly = False
        cmbDescription.Enabled = True

        btnAdd.Enabled = False
    End Sub
    Private Function checkDuplicate(itemCode As String, quotationNo As String) As Boolean
        Dim present As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `item_code`, `quotation_no` FROM `quotation_details` WHERE `item_code`='" + itemCode + "' AND `quotation_no`='" + quotationNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read

                present = True

                Exit While
            End While
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return present
    End Function
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Dim invoiceLimit As Double = Val(LCurrency.getValue(txtInvoiceLimit.Text))
        ' Dim creditLimit As Double = Val(LCurrency.getValue(txtCreditLimit.Text))
        ' Dim creditBalance As Double = Val(LCurrency.getValue(txtCreditBalance.Text))
        Dim currentTotal As Double = Val(LCurrency.getValue(txtTotal.Text))
        Dim amount As Double = LCurrency.getValue(txtAmount.Text)


        If User.authorize("CREATE & CANCEL PACKING LIST") = False Then
            ' MsgBox("Access Denied", vbOKOnly + vbExclamation, "Access denied")
            '  Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        If currentRow = -1 Then
            currentRow = dtgrdItemList.RowCount
        End If
        txtPrice.ReadOnly = True
        If txtInvoiceNo.Text = "" Then
            MsgBox("Select new")
            clearFields()
            Cursor = Cursors.Default
            Exit Sub
        End If
        Dim status As String = (New Quotation).getStatus(txtInvoiceNo.Text)
        If status = "CANCELED" Or status = "ARCHIVED" Then
            MsgBox("Could not edit, quotation invalid", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearFields()
            Cursor = Cursors.Default
            Exit Sub
        End If

        If cmbCustomerName.Text = "" Then
            MsgBox("Could not add item, customer required", vbOKOnly + vbCritical, "Error: Missing Information")
            Cursor = Cursors.Default
            Exit Sub
        End If
        If check(txtInvoiceNo.Text, token) = False And txtId.Text <> "" Then
            MsgBox("Could not modify document, the document has been modified by some one else. Please reload the document to continue", vbOKOnly + vbExclamation, "Invalid Operation")
            Cursor = Cursors.Default
            Exit Sub
        End If
        Dim barCode As String = txtBarCode.Text
        Dim itemCode As String = txtItemCode.Text
        Dim description As String = cmbDescription.Text
        Dim qty As String = txtQty.Text

        Dim price As String = LCurrency.getValue(txtPrice.Text)

        If itemCode = "" Then
            MsgBox("Item required", vbOKOnly + vbCritical, "Error: Missing information")
            Cursor = Cursors.Default
            Exit Sub
        End If
        If Val(qty) <= 0 Then
            MsgBox("Could not add item. Invalid issue qty, qty should be non-negative", vbOKOnly + vbCritical, "Error: Invalid entry")
            Cursor = Cursors.Default
            Exit Sub
        End If


        Dim _new As Boolean = False
        Dim list As Quotation
        If txtId.Text = "" Then
            _new = True
            list = New Quotation
            list.GL_QUOTATION_NO = txtInvoiceNo.Text
            Dim quotationDate As String = (New Day).getCurrentDay.ToString("yyyy-MM-dd")
            list.GL_QUOTATION_DATE = quotationDate
            list.GL_CUSTOMER_NAME = cmbCustomerName.Text
            list.GL_STATUS = "NEW"
            '   list.GL_CUSTOMER_ADDRESS = txtCustomerAddress.Text
            If list.isQuotationExist(txtInvoiceNo.Text) = False Then
                If list.addNewQuotation() = True Then
                    token = touch(txtInvoiceNo.Text)
                    list.getQuotation(txtInvoiceNo.Text)
                    txtId.Text = list.GL_ID
                    btnSave.Enabled = True
                End If
            Else

            End If
        End If
        If txtId.Text = "" Then
            MsgBox("Could not add, please restart application")
            Cursor = Cursors.Default
            Exit Sub
        End If
        list = New Quotation
        list.GL_QUOTATION_NO = txtInvoiceNo.Text
        list.GL_ITEM_CODE = itemCode
        list.GL_DESCRIPTION = description
        list.GL_PRICE = price
        list.GL_QTY = qty


        If check(txtInvoiceNo.Text, token) = False Then
            MsgBox("Could not modify document, the document has been modified by some one else. Please reload the document to continue", vbOKOnly + vbExclamation, "Invalid Operation")
            Cursor = Cursors.Default
            Exit Sub
        End If

        If checkDuplicate(itemCode, txtInvoiceNo.Text) = False Then
            If dtgrdItemList.RowCount >= 200 Then
                MsgBox("Maximum number of items in item list reached. The maximum allowed entries is 200", vbOKOnly + vbCritical, "Invalid operation")
                Cursor = Cursors.Default
                Exit Sub
            End If
            list.addQuotationDetails()
        Else
            list.editQuotationDetails(txtInvoiceNo.Text, itemCode)
        End If
        If _new = True Then
            refreshQuotationLists()
        End If
        refreshList()
        clearFields()
        unLockFields()
        currentRow = -1
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) ' Handles btnCancel.Click
        If User.authorize("CREATE & CANCEL PACKING LIST") = False Then
            '' MsgBox("Access Denied", vbOKOnly + vbExclamation, "Access denied")
            '' Exit Sub
        End If
        If txtInvoiceNo.Text = "" Then
            MsgBox("Please select document")
            Exit Sub
        End If
        Dim status As String = (New Quotation).getStatus(txtInvoiceNo.Text)
        If status = "NEW" Then
            'continue
        Else
            MsgBox("Can not cancel, only a New invoice can be canceled", vbOKOnly + vbCritical, "Error: Invalid operation")
            Exit Sub
        End If
        If check(txtInvoiceNo.Text, token) = False Then
            MsgBox("Could not modify document, the document has been modified by some one else. Please reload the document to continue", vbOKOnly + vbExclamation, "Invalid Operation")
            Cursor = Cursors.Default
            Exit Sub
        End If

        If 1 = 1 Then ' User.authorize("APPROVE PACKING LIST") = True Then
            If txtInvoiceNo.Text = "" Then
                MsgBox("Select an invoice to cancel", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim res As Integer = MsgBox("Cancel invoice: " + txtInvoiceNo.Text + " ? Invoice can not be used after canceling", vbYesNo + vbQuestion, "Cancel document?")
            If res = DialogResult.Yes Then

                Dim list As SalesInvoice = New SalesInvoice
                If list.cancelInvoice(txtInvoiceNo.Text) = True Then
                    MsgBox("Cancel Success", vbOKOnly + vbInformation, "Success")
                Else
                    MsgBox("Cancel failed", vbOKOnly + vbExclamation, "Failed")
                End If



            End If
            txtStatus.Text = (New SalesInvoice).getStatus(txtInvoiceNo.Text)
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation, "Error: Access denied")
        End If
        refreshQuotationLists()
    End Sub



    Private Sub clearItemdetails()
        txtBarCode.Text = ""
        txtItemCode.Text = ""
        cmbDescription.Text = ""
        txtPrice.Text = ""
        txtQty.Text = ""
        txtAmount.Text = ""
        cmbDescription.Enabled = True
        txtBarCode.ReadOnly = False
        txtItemCode.ReadOnly = False
    End Sub



    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtPrice.ReadOnly = True
        clearItemdetails()
        currentRow = -1
    End Sub

    Private Function validateInputs() As Boolean
        Dim valid As Boolean = True
        If txtInvoiceNo.Text = "" Then
            valid = False
            MsgBox("Operation failed, quotation no required", vbOKOnly + vbCritical, "Error: Missing information")
            Return valid
            Exit Function
        End If
        If cmbCustomerName.Text = "" Then
            valid = False
            MsgBox("Operation failed, customer required", vbOKOnly + vbCritical, "Error: Missing information")
            Return valid
            Exit Function
        End If
        Return valid
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If User.authorize("CREATE & CANCEL PACKING LIST") = False Then
            '    MsgBox("Access Denied", vbOKOnly + vbExclamation, "Access denied")
            '   Exit Sub
        End If
        If txtInvoiceNo.Text = "" Then
            MsgBox("Please select document")
            Exit Sub
        End If

        Dim status As String = (New Quotation).getStatus(txtInvoiceNo.Text)
        If status = "CANCELED" Or status = "ARCHIVED" Then
            MsgBox("Could not modify. Only valid qoutations can be modified", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If
        If check(txtInvoiceNo.Text, token) = False Then
            MsgBox("Could not modify document, the document has been modified by some one else. Please reload the document to continue", vbOKOnly + vbExclamation, "Invalid Operation")
            Exit Sub
        End If

        'validate entries
        If validateInputs() = False Then
            Exit Sub
        End If
        Dim list As New Quotation
        list.GL_QUOTATION_NO = txtInvoiceNo.Text
        list.GL_QUOTATION_DATE = txtIssueDate.Text
        list.GL_STATUS = txtStatus.Text
        list.GL_CUSTOMER_NAME = cmbCustomerName.Text


        '    list.GL_CUSTOMER_ADDRESS = txtCustomerAddress.Text


        'check if new or existing 

        If txtId.Text = "" Then
            'save a new record
            If list.addNewQuotation() = True Then
                list.getQuotation(txtInvoiceNo.Text)
                MsgBox("Save success", vbOKOnly + vbInformation, "Success")
            Else
                MsgBox("Saving failed", vbOKOnly + vbExclamation, "Failure")
            End If
        Else
            'save an existing record

            If list.editQuotation(txtInvoiceNo.Text) = True Then
                list.getQuotation(txtInvoiceNo.Text)
                MsgBox("Edit success", vbOKOnly + vbInformation, "Success")
            Else
                MsgBox("Editing failed", vbOKOnly + vbExclamation, "Failure")
            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        resetAll()
    End Sub

    Private Sub resetAll()
        oldPrice = 0

        txtId.Text = ""
        txtInvoiceNo.Text = ""
        txtIssueDate.Text = ""
        cmbCustomerName.SelectedItem = Nothing
        txtStatus.Text = ""


        'txtCustomerAddress.Text = ""

        txtBarCode.Text = ""
        txtItemCode.Text = ""
        cmbDescription.SelectedItem = Nothing
        cmbDescription.Text = ""
        txtPrice.Text = ""

        txtQty.Text = ""

        'lock
        txtInvoiceNo.ReadOnly = True

        txtPrice.ReadOnly = True
        txtBarCode.ReadOnly = True
        txtItemCode.ReadOnly = True
        cmbDescription.Enabled = False
        txtIssueDate.Text = ""
        txtStatus.Text = ""

        'unlock

        btnSave.Enabled = False


        dtgrdItemList.Rows.Clear()
    End Sub





    Private Sub btnArchive_Click(sender As Object, e As EventArgs) ' Handles btnArchive.Click
        If User.authorize("ARCHIVE DOCUMENTS") = False Then
            MsgBox("Access Denied", vbOKOnly + vbExclamation, "Access denied")
            Exit Sub
        End If

        Dim status As String = (New SalesInvoice).getStatus(txtInvoiceNo.Text)
        If status = "PAID" Then
            'continue
        Else
            If txtInvoiceNo.Text = "" Then
                MsgBox("Select an invoice to archive", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            MsgBox("Can not archive, only fully paid incoices can be archived", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If

        If check(txtInvoiceNo.Text, token) = False Then
            MsgBox("Could not modify document, the document has been modified by some one else. Please reload the document to continue", vbOKOnly + vbExclamation, "Invalid Operation")
            Cursor = Cursors.Default
            Exit Sub
        End If

        If 1 = 1 Then ' User.authorize("APPROVE LPO") = True Then
            If txtInvoiceNo.Text = "" Then
                MsgBox("Select a document to archive", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim res As Integer = MsgBox("Archive invoice: " + txtInvoiceNo.Text + " ? Invoice will be sent to archives for future references", vbYesNo + vbQuestion, "Archive packing list?")
            If res = DialogResult.Yes Then

                Dim list As SalesInvoice = New SalesInvoice
                If list.archiveInvoice(txtInvoiceNo.Text) = True Then
                    MsgBox("Archive Success", vbOKOnly + vbInformation, "Success")
                Else
                    MsgBox("Archive failed", vbOKOnly + vbExclamation, "Failure")
                End If
            End If
            txtStatus.Text = (New SalesInvoice).getStatus(txtInvoiceNo.Text)
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
        refreshQuotationLists()
    End Sub




    Private Function getSalesPersonId(name) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id`,`full_name` FROM `sales_persons` WHERE `full_name`='" + name + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return id
    End Function

    Dim saleId As String = ""

    Private Sub refreshQuotationLists()
        dtgrdInvoiceLists.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `quotation_id`, `quotation_no`, `date_time`, `quotation_date`, `status`, `name`, `contact`, `user_id`, `amount`, `customer_no`, `touch` FROM `quotations`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim quotationNo As String = ""
            Dim quotationDate As String = ""
            Dim status As String = ""
            Dim customer As String = ""

            While reader.Read
                Dim item As New Item
                quotationNo = reader.GetString("quotation_no")
                quotationDate = reader.GetString("quotation_date")
                status = reader.GetString("status")
                ' customer = (New SalesInvoice).get(reader.GetString("sales_person_id"))

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = quotationNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = quotationDate
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = "Status: " + status + " Customer: " ' + salesPerson
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdInvoiceLists.Rows.Add(dtgrdRow)

            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtgrdPackingLists_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdInvoiceLists.CellClick
        Dim r As Integer = dtgrdInvoiceLists.CurrentRow.Index
        Dim quotationNo As String = dtgrdInvoiceLists.Item(1, r).Value.ToString
        txtInvoiceNo.Text = quotationNo
        txtInvoiceNo.ReadOnly = False
        search()
    End Sub




    Private Sub txtStatus_TextChanged(sender As Object, e As EventArgs) Handles txtStatus.TextChanged
        If txtStatus.Text = "" Or txtStatus.Text = "NEW" Then
            cmbCustomerName.Enabled = True
        Else
            cmbCustomerName.Enabled = False
        End If
    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged
        If Not IsNumeric(txtQty.Text) Or txtQty.Text.Contains("-") Or Val(txtQty.Text) < 0 Then
            txtQty.Text = ""
        End If
        txtAmount.Text = LCurrency.displayValue(Val(txtQty.Text) * Val(LCurrency.getValue(txtPrice.Text)))
    End Sub


    Dim oldPrice As Double = 0
    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        If txtPrice.ReadOnly = True And txtPrice.Text <> "" And Val(LCurrency.getValue(txtPrice.Text)) > 0 Then
            Dim res As Integer = MsgBox("Change price?", vbYesNo + vbQuestion, "Customize price")
            If res = DialogResult.Yes Then
                oldPrice = Val(LCurrency.getValue(txtPrice.Text))
                txtPrice.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged
        If txtPrice.ReadOnly = False And (Not IsNumeric(txtPrice.Text) Or txtPrice.Text.Contains("-")) Then
            txtPrice.Text = oldPrice.ToString
            oldPrice = 0
            txtPrice.ReadOnly = True
        End If
        txtAmount.Text = LCurrency.displayValue(Val(txtQty.Text) * Val(LCurrency.getValue(txtPrice.Text)))
    End Sub
    'maintains the visible position of a row after refresh
    Dim currentRow As Integer = -1

    Private Sub btnArchiveAll_Click(sender As Object, e As EventArgs) ' Handles btnArchiveAll.Click
        If User.authorize("ARCHIVE DOCUMENTS") = False Then
            MsgBox("Access Denied", vbOKOnly + vbExclamation, "Access denied")
            Exit Sub
        End If
        resetAll()
        Dim res As Integer = MsgBox("Are you sure you want to archive all cleared packing list documents? All the cleared documents will be sent to archives for future reference.", vbQuestion + vbYesNo, "Archive all cleared packing lists")
        If res = DialogResult.Yes Then
            Dim noOfdocuments As Integer = 0
            Try
                Cursor = Cursors.WaitCursor
                For i As Integer = 0 To dtgrdInvoiceLists.RowCount - 1
                    Dim no As String = dtgrdInvoiceLists.Item(0, i).Value.ToString
                    Dim list As SalesInvoice = New SalesInvoice
                    Dim status As String = list.getStatus(no)
                    If status = "PAID" Then
                        noOfdocuments = noOfdocuments + 1
                    End If
                Next
                If noOfdocuments = 0 Then
                    MsgBox("No documents to archive, only completed and debt free documents can be archived", vbOKOnly + vbExclamation, "No documents to archive")
                    Cursor = Cursors.Default
                    Exit Sub
                Else
                    Dim confirm As Integer = MsgBox(noOfdocuments.ToString + "  documents will be archived, continue?", vbYesNo + vbQuestion, "Concirm archive")
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
                For i As Integer = 0 To dtgrdInvoiceLists.RowCount - 1
                    Dim no As String = dtgrdInvoiceLists.Item(0, i).Value.ToString
                    Dim list As SalesInvoice = New SalesInvoice
                    Dim status As String = list.getStatus(no)
                    If status = "COMPLETED" Then
                        'archive
                        list.archiveInvoice(no)
                    End If
                Next
                MsgBox(noOfdocuments.ToString + " document(s) archived successifuly")
            Catch ex As Exception
                '  MsgBox(ex.ToString)
            End Try
            refreshQuotationLists()
            Cursor = Cursors.Default
        End If
    End Sub
    Dim token As String = ""
    Private Function touch(quotationNo As String) As String
        Dim token As String = Utility.generateRandom20TokenWithDateTime()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `quotations` SET `touch`='" + token + "' WHERE `quotation_no`='" + quotationNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            token = ""
        End Try
        Return token
    End Function
    Private Function check(quotationNo As String, token As String) As Boolean
        Dim conn As New MySqlConnection(Database.conString)
        Dim command As New MySqlCommand()
        Dim query As String = "SELECT `quotation_no`, `touch` FROM `quotations` WHERE `quotation_no`='" + txtInvoiceNo.Text + "'"
        conn.Open()
        command.CommandText = query
        command.Connection = conn
        command.CommandType = CommandType.Text
        Dim reader As MySqlDataReader = command.ExecuteReader()
        While reader.Read
            If token = reader.GetString("touch") And token <> "" Then
                Return True
            End If
        End While
        Return False
    End Function

    Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs) Handles cmbCustomerName.TextChanged
        If cmbCustomerName.Text = "" Then
            cmbCustomerName.Text = ""
        End If
    End Sub

    Private Sub cmbCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCustomerName.TextChanged
        refreshCustomer()
    End Sub
    Private Sub refreshCustomer()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `customer_id`, `customer_code`, `customer_name`, `address`, `post_code`, `physical_address`, `contact_name`, `bank_acc_name`, `bank_acc_address`, `bank_post_code`, `bank_name`, `bank_acc_no`, `telephone`, `mob`, `email`, `fax`, `tin`, `vrn`, `invoice_limit`, `credit_limit`, `status`, `credit_balance` FROM `corporate_customers` WHERE  `customer_name`='" + cmbCustomerName.Text + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtCustomerNo.Text = reader.GetString("customer_code")
                txtContact.Text = reader.GetString("post_code") + reader.GetString("address") + "\n" + reader.GetString("physical_address") + "\n" + reader.GetString("telephone") + "\n" + reader.GetString("email")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            cmbCustomerName.Text = ""
            MsgBox(ex.Message)
        End Try
        If cmbCustomerName.Text = "" Then
            txtCustomerNo.Text = ""
            txtContact.Text = ""
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If User.authorize("PRINT PACKING LIST") = False Then
            ' MsgBox("Access Denied", vbOKOnly + vbExclamation, "Access denied")
            '   Exit Sub
        End If
        If txtInvoiceNo.Text = "" Then
            MsgBox("Please select document")
            Exit Sub
        End If
        Dim status As String = (New Quotation).getStatus(txtInvoiceNo.Text)
        If status = "CANCELED" Or status = "ARCHIVED" Then

            MsgBox("Could not print quotation, Document invalid", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If
        If check(txtInvoiceNo.Text, token) = False Then
            MsgBox("Could not print document, the document has been modified by some one else. Please reload the document to continue", vbOKOnly + vbExclamation, "Invalid Operation")
            Cursor = Cursors.Default
            Exit Sub
        End If
        If 1 = 1 Then ' User.authorize("PRINT PACKING LIST") = True Then
            If txtInvoiceNo.Text = "" Then
                MsgBox("Select quotation to print", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim res As Integer = 0

            res = MsgBox("Print quotation : " + txtInvoiceNo.Text + " ? ", vbYesNo + vbQuestion, "Print?")

            If res = DialogResult.Yes Then
                'approve order

                If dtgrdItemList.RowCount = 0 Then
                    MsgBox("Could not approve an empty quotation", vbOKOnly + vbExclamation, "Error: No selection")
                    Exit Sub
                End If
                Dim list As Quotation = New Quotation
                Dim success As Boolean = True

                txtStatus.Text = (New Quotation).getStatus(txtInvoiceNo.Text)
                If success = True Then
                    'now do the actual printing in pdf

                    Dim quotationNo As String = txtInvoiceNo.Text
                    If quotationNo = "" Then
                        MsgBox("Select a document to print.", vbOKOnly + vbCritical, "Error:No selection")
                        Exit Sub
                    End If
                    If dtgrdItemList.RowCount = 0 Then
                        MsgBox("Can not print an empty document. Please select document print", vbOKOnly + vbCritical, "Error: No selection")
                        Exit Sub
                    End If

                    Dim document As Document = New Document

                    document.Info.Title = "Quotation"
                    document.Info.Subject = "Quotation"
                    document.Info.Author = "Orbit"

                    defineStyles(document)
                    createDocument(document)

                    Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
                    myRenderer.Document = document
                    myRenderer.RenderDocument()

                    Dim filename As String = LSystem.getRoot & "\Quotation " & quotationNo & ".pdf"

                    myRenderer.PdfDocument.Save(filename)

                    Process.Start(filename)

                End If

            End If
            txtStatus.Text = (New SalesInvoice).getStatus(txtInvoiceNo.Text)
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
        refreshQuotationLists()
    End Sub

    Private Sub cmbCustomerName_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbCustomerName.SelectedIndexChanged

    End Sub

    Private Sub dtgrdItemList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdItemList.CellContentClick

    End Sub
End Class