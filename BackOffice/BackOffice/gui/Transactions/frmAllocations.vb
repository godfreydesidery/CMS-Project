Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables

Public Class frmAllocations

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


    Private Function clear()
        txtInvoiceNo.Text = ""

        Return vbNull
    End Function

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If User.authorize("CREATE & CANCEL PACKING LIST") = False Then
            '   MsgBox("Access Denied", vbOKOnly + vbExclamation, "Access denied")
            '  Exit Sub
        End If

        txtAllocationNo.Text = ""
        txtAllocationDate.Text = ""
        txtCustomerNo.Text = ""
        cmbCustomerName.Text = ""

        txtInvoiceNo.Text = ""
        txtInvoiceTotal.Text = ""
        txtInvoiceDue.Text = ""

        txtReceiptNo.Text = ""
        txtReceiptTotal.Text = ""
        txtReceiptDue.Text = ""


        txtAllocationNo.ReadOnly = True




        txtAllocationDate.Text = Day.DAY
        btnSave.Enabled = False

        txtAllocationNo.Text = (New Allocation).generateAllocationNo
        If txtAllocationNo.Text = "" Then
            txtAllocationNo.Text = "NAN"
        End If
        dtgrdInvoices.Rows.Clear()
        dtgrdReceipts.Rows.Clear()
    End Sub

    Private Function refreshList()
        Dim total As Double = 0
        Cursor = Cursors.WaitCursor
        dtgrdInvoices.Rows.Clear()
        dtgrdReceipts.Rows.Clear()
        Try

            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `invoice_id`, `invoice_no`, `date_time`, `invoice_date`, `status`, `name`, `contact`, `user_id`, `amount`, `customer_no`, `touch`, `paid` FROM `sales_invoices` WHERE `customer_no`='" + txtCustomerNo.Text + "' AND `amount` - `paid` > 0"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim id As String = ""
            Dim invoiceNo As String = ""
            Dim invoiceDate As String = ""
            Dim invoiceDue As Double = 0



            While reader.Read
                invoiceNo = reader.GetString("invoice_no")
                invoiceDate = reader.GetString("invoice_date")
                invoiceDue = Val(reader.GetString("amount")) - Val(reader.GetString("paid"))


                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = invoiceNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = invoiceDate
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(invoiceDue)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdInvoices.Rows.Add(dtgrdRow)

            End While

            conn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try

            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `receipt_id`, `receipt_no`, `date_time`, `receipt_date`, `customer_no`, `payment_mode`, `amount`, `comments`, `allocated` FROM `sales_receipts` WHERE `customer_no`='" + txtCustomerNo.Text + "' AND `amount` - `allocated` > 0"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim id As String = ""
            Dim receiptNo As String = ""
            Dim receiptDate As String = ""
            Dim receiptDue As Double = 0



            While reader.Read
                receiptNo = reader.GetString("receipt_no")
                receiptDate = reader.GetString("receipt_date")
                receiptDue = Val(reader.GetString("amount")) - Val(reader.GetString("allocated"))


                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = receiptNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = receiptDate
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(receiptDue)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdReceipts.Rows.Add(dtgrdRow)

            End While

            conn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        dtgrdInvoices.ClearSelection()
        dtgrdReceipts.ClearSelection()



        Cursor = Cursors.Arrow
        Return vbNull
    End Function



    Dim oldRow As Integer = -1
    Dim glsn As String = ""

    Private Sub searchInvoice(invoiceNo As String)
        Dim conn As New MySqlConnection(Database.conString)
        Try
            Dim suppcommand As New MySqlCommand()
            Dim supplierQuery As String = "SELECT `invoice_id`, `invoice_no`, `date_time`, `invoice_date`, `status`, `name`, `contact`, `user_id`, `amount`, `customer_no`, `touch`, `paid` FROM `sales_invoices` WHERE `invoice_no`='" + invoiceNo + "'"
            conn.Open()
            suppcommand.CommandText = supplierQuery
            suppcommand.Connection = conn
            suppcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = suppcommand.ExecuteReader
            cmbCustomerName.Items.Clear()
            If reader.HasRows Then
                While reader.Read
                    txtInvoiceNo.Text = reader.GetString("invoice_no")
                    txtInvoiceTotal.Text = LCurrency.displayValue(reader.GetString("amount"))
                    txtInvoiceDue.Text = LCurrency.displayValue((Val(reader.GetString("amount")) - Val(reader.GetString("paid"))).ToString)
                End While
            End If
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub searchReceipt(receiptNo As String)
        Dim conn As New MySqlConnection(Database.conString)
        Try
            Dim suppcommand As New MySqlCommand()
            Dim supplierQuery As String = "SELECT `receipt_id`, `receipt_no`, `date_time`, `receipt_date`, `customer_no`, `payment_mode`, `amount`, `comments`, `allocated` FROM `sales_receipts` WHERE `receipt_no`='" + receiptNo + "'"
            conn.Open()
            suppcommand.CommandText = supplierQuery
            suppcommand.Connection = conn
            suppcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = suppcommand.ExecuteReader
            cmbCustomerName.Items.Clear()
            If reader.HasRows Then
                While reader.Read
                    txtReceiptNo.Text = reader.GetString("receipt_no")
                    txtReceiptTotal.Text = LCurrency.displayValue(reader.GetString("amount"))
                    txtReceiptDue.Text = LCurrency.displayValue((Val(reader.GetString("amount")) - Val(reader.GetString("allocated"))).ToString)
                End While
            End If
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            MsgBox(ex.Message)
            Exit Sub
        End Try
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





    Private Sub frmSalesInvoice_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtInvoiceNo.Text = ""
        dtgrdInvoices.Rows.Clear()
        dtgrdReceipts.Rows.Clear()

    End Sub

    Private Sub clearFields()
        txtInvoiceNo.Text = ""
        txtInvoiceDue.Text = ""
        txtInvoiceTotal.Text = ""
        txtCustomerNo.Text = ""
        cmbCustomerName.SelectedItem = Nothing
        cmbCustomerName.Text = ""
        txtReceiptDue.Text = ""
    End Sub
    Private Sub lockFields()

    End Sub
    Private Sub unLockFields()

    End Sub


    Private Function validateInputs() As Boolean
        Dim valid As Boolean = True
        If txtInvoiceNo.Text = "" Then
            valid = False
            MsgBox("Operation failed, invoice no required", vbOKOnly + vbCritical, "Error: Missing information")
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



    Dim token As String = ""
    Private Function touch(issueNo As String) As String
        Dim token As String = Utility.generateRandom20TokenWithDateTime()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `sales_invoices` SET `touch`='" + token + "' WHERE `invoice_no`='" + issueNo + "'"
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
    Private Function check(issueNo As String, token As String) As Boolean
        Dim conn As New MySqlConnection(Database.conString)
        Dim command As New MySqlCommand()
        Dim query As String = "SELECT `invoice_no`, `touch` FROM `sales_invoices` WHERE `invoice_no`='" + txtInvoiceNo.Text + "'"
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
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            cmbCustomerName.Text = ""
            MsgBox(ex.Message)
        End Try
        If cmbCustomerName.Text = "" Then
            txtCustomerNo.Text = ""

        End If
    End Sub



    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub



    Private Sub frmAllocations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearFields()
        txtAllocationNo.ReadOnly = True


        Dim customer As New CorporateCustomer
        longCustomerList = customer.getCustomers("")
    End Sub
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

    Private Sub cmbCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCustomerName.SelectedIndexChanged
        txtCustomerNo.Text = (New CorporateCustomer).getCustomerCode("", cmbCustomerName.Text)
        dtgrdInvoices.Rows.Clear()
        dtgrdReceipts.Rows.Clear()
        refreshList()
    End Sub

    Private Sub dtgrdInvoices_CellContentClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdInvoices.RowHeaderMouseClick
        dtgrdReceipts.ClearSelection()

        txtReceiptNo.Text = ""
        txtReceiptTotal.Text = ""
        txtReceiptDue.Text = ""

        Dim r As Integer = dtgrdInvoices.CurrentRow.Index
        Dim invoiceNo As String = dtgrdInvoices.Item(0, r).Value.ToString
        searchInvoice(invoiceNo)
    End Sub

    Private Sub dtgrdReceipts_CellContentClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdReceipts.RowHeaderMouseClick
        If txtInvoiceNo.Text = "" Then
            MsgBox("Please select invoice", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If
        Dim r As Integer = dtgrdReceipts.CurrentRow.Index
        Dim receiptNo As String = dtgrdReceipts.Item(0, r).Value.ToString
        searchReceipt(receiptNo)
    End Sub

    Private Sub btnAllocate_Click(sender As Object, e As EventArgs) Handles btnAllocate.Click
        If txtInvoiceNo.Text = "" Then
            MsgBox("Please select invoice", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If
        If txtReceiptNo.Text = "" Then
            MsgBox("Please select receipt", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If
        allocate(txtInvoiceNo.Text, txtReceiptNo.Text)
    End Sub

    Private Sub allocate(invoiceNo As String, receiptno As String)
        Dim invoiceDue As Double = Val(LCurrency.getValue(txtInvoiceDue.Text))
        Dim receiptDue As Double = Val(LCurrency.getValue(txtReceiptDue.Text))
        Dim allocationAmount As Double = Val(txtAllocationAmount.Text)
        If allocationAmount > receiptDue Then
            MsgBox("Could not allocate, allocation amount exceeds receipt by " + (allocationAmount - receiptDue).ToString, vbOKOnly + vbExclamation, "Error: Invalid Entry")
            Exit Sub
        End If
        '    Dim res As Integer = MsgBox("Allocate " + allocationAmount + " to invoice " + txtInvoiceNo.Text + "?", vbYesNo + vbQuestion, "Allocate")
        '    If res = DialogResult.Yes Then
        Dim allocation As New Allocation
        allocation.addAllocation(txtAllocationNo.Text, txtAllocationDate.Text, txtInvoiceNo.Text, txtReceiptNo.Text, allocationAmount)
        refreshList()
        '   End If
    End Sub

End Class