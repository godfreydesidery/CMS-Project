Imports Devart.Data.MySql

Public Class frmSalesReceipts
    Dim RECORD_MODE As String = ""
    Private Function clearFields()
        txtReceiptNo.Text = ""
        cmbCustomer.SelectedItem = Nothing
        cmbCustomer.Text = ""
        cmbPaymentMode.SelectedItem = Nothing
        cmbPaymentMode.Text = ""
        txtReceiptDate.Text = ""
        txtAmount.Text = ""
        txtComments.Text = ""
        txtAllocated.Text = ""
        Return vbNull
    End Function
    Private Function lock()
        cmbCustomer.Enabled = False
        txtAmount.ReadOnly = True
        txtComments.ReadOnly = True
        Return vbNull
    End Function
    Private Function unlock()
        cmbCustomer.Enabled = True
        txtAmount.ReadOnly = False
        txtComments.ReadOnly = False
        Return vbNull
    End Function
    Private Function getValues()
        Dim receipt As New SalesReceipt

        receipt.GL_RECEIPT_NO = txtReceiptNo.Text
        receipt.GL_RECEIPT_DATE = txtReceiptDate.Text
        receipt.GL_AMOUNT = txtAmount.Text
        receipt.GL_COMMENTS = txtComments.Text
        Return vbNull
    End Function
    Private Function setValues()

        Return vbNull
    End Function
    Private Function saveNew() As Boolean
        Dim saved As Boolean = False
        Dim receipt As New SalesReceipt
        If validateFields() = True Then
            'continues with operation
        Else
            'exit from the operation
            'if fields are not valid
            Return saved
            Exit Function
        End If

        If receipt.addReceipt(txtReceiptNo.Text, txtReceiptDate.Text, (New CorporateCustomer).getCustomerCode("", cmbCustomer.Text), cmbPaymentMode.Text, LCurrency.getValue(txtAmount.Text), txtComments.Text) = True Then
            saved = True
        End If
        Return saved
    End Function
    Private Function saveExisting() As Boolean
        Dim saved As Boolean = False

        Dim receipt As New SalesReceipt
        If validateFields() = True Then
            'continues with operation
        Else
            'exit from the operation
            'if fields are not valid
            Return saved
            Exit Function

        End If

        If receipt.editReceipt(txtReceiptNo.Text, cmbPaymentMode.Text, txtComments.Text) = True Then
            saved = True
        End If
        Return saved
    End Function
    Private Function validateFields() As Boolean
        Dim valid As Boolean = True

        Return valid
    End Function
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Public Shared GLOBAL_RECEIPT_NO As String = ""


    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        RECORD_MODE = "NEW"
        dtgrdReceiptsList.Enabled = False
        clearFields() 'clear the fields
        txtReceiptNo.ReadOnly = False
        btnDelete.Enabled = False
        btnSearch.Enabled = False
        btnSave.Enabled = True
        REC_PRESENT = False
        unlock()
        txtReceiptNo.ReadOnly = True
        txtReceiptNo.Text = (New SalesReceipt).generateReceiptNo
        txtReceiptDate.Text = Day.DAY
    End Sub
    Private Function search(receiptNo As String)

        Dim receipt As New SalesReceipt
        If receipt.search(receiptNo) = True Then
            'get values
            txtReceiptNo.Text = receipt.GL_RECEIPT_NO
            cmbCustomer.Text = (New CorporateCustomer).getCustomerName("", receipt.GL_CUSTOMER_NO)
            txtReceiptDate.Text = receipt.GL_RECEIPT_DATE
            cmbPaymentMode.Text = receipt.GL_PAYMENT_MODE
            txtAmount.Text = LCurrency.displayValue(receipt.GL_AMOUNT)
            txtAllocated.Text = LCurrency.displayValue(receipt.GL_ALLOCATED)
            txtComments.Text = receipt.GL_COMMENTS


            dtgrdReceiptsList.Enabled = True
            btnDelete.Enabled = True
            txtReceiptNo.ReadOnly = True
            RECORD_MODE = ""
            lock()
            REC_PRESENT = True
        Else
            MsgBox("The requested record could not be found", vbOKOnly + vbCritical, "Error: Not found")
        End If

        Return vbNull
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search(txtReceiptNo.Text)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If RECORD_MODE = "NEW" Then

            If saveNew() = True Then
                'record saved successifuly
                dtgrdReceiptsList.Enabled = True
                RECORD_MODE = ""
                refreshList()
                REC_PRESENT = True
                MsgBox("New receipt created successifully", vbOKOnly + vbInformation, "Success: Supplier created")

            Else
                'record could not be saved
            End If
        Else
            If saveExisting() = True Then
                'record saved successifully
                dtgrdReceiptsList.Enabled = True
                refreshList()
                REC_PRESENT = True
                MsgBox("Receipt modified successifully", vbOKOnly + vbInformation, "Success: Edit supplier")
            Else
                'record could not be saved
            End If
        End If
    End Sub
    Dim REC_PRESENT As Boolean = False
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        btnDelete.Enabled = False
        btnSearch.Enabled = True
        If REC_PRESENT = False Then
            txtReceiptNo.ReadOnly = False
            btnSave.Enabled = False
        Else
            txtReceiptNo.ReadOnly = True
            btnSave.Enabled = True
        End If
        dtgrdReceiptsList.Enabled = True
        'clearFields()
        unlock()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected customer? All information about the customer will be removed from the system. This action can not be undone.", vbYesNo + vbQuestion, "Delete Supplier")
        If res = DialogResult.Yes Then
            'proceed
        Else
            'discard operation
            Exit Sub
        End If
        Dim receipt As New SalesReceipt
        If receipt.deleteReceipt(txtReceiptNo.Text) = True Then
            btnDelete.Enabled = False
            'dtgrdSuppliers.Enabled = False
            clearFields() 'clear the fields
            refreshList()
            REC_PRESENT = False
            MsgBox("Customer record deleted successifully", vbOKOnly + vbInformation, "Success: Delete customer record")
        Else
            MsgBox("Could not delete the selected customer record", vbOKOnly + vbCritical, "Error: Delete failed")
        End If

    End Sub

    Private Sub txtno_TextChanged(sender As Object, e As EventArgs) Handles txtReceiptNo.TextChanged
        If txtReceiptNo.Text.Contains("'") Then
            txtReceiptNo.Text = ""
        End If
    End Sub
    Private Sub txtNo_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtReceiptNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search(txtReceiptNo.Text)
        End If
    End Sub



    Private Sub frmSuppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearFields()
        refreshList()
        Dim customer As New CorporateCustomer
        longList = customer.getCustomers("")
    End Sub
    Private Function refreshList()
        dtgrdReceiptsList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `receipt_id`, `receipt_no`, `date_time`, `receipt_date`, `customer_no`, `payment_mode`, `amount`, `comments`, `allocated` FROM `sales_receipts`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim Id As String = ""
            Dim receiptNo As String = ""
            Dim receiptDate As String = ""
            Dim customer As String = ""
            Dim summary As String = ""

            While reader.Read

                Id = reader.GetString("receipt_id")
                receiptNo = reader.GetString("receipt_no")
                receiptDate = reader.GetString("receipt_date")
                customer = reader.GetString("customer_no") + " " + (New CorporateCustomer).getCustomerName("", reader.GetString("customer_no"))
                summary = "Amnt: " + LCurrency.displayValue(reader.GetString("amount")) + "  " + "Alloc: " + LCurrency.displayValue(reader.GetString("allocated"))

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = Id
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = receiptNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = receiptDate
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = customer
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = summary
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdReceiptsList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



        Return vbNull
    End Function

    Private Sub dtgrdSuppliers_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdReceiptsList.RowHeaderMouseClick
        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            row = dtgrdReceiptsList.CurrentRow.Index
            col = dtgrdReceiptsList.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try
        Dim receiptNo As String = ""
        row = dtgrdReceiptsList.CurrentRow.Index
        receiptNo = dtgrdReceiptsList.Item(1, row).Value.ToString
        search(receiptNo)
    End Sub



    Dim file As String = "C:\Sales Receipts.xls"


    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)
    Private Sub cmbCustomer_KeyUp(sender As Object, e As EventArgs) Handles cmbCustomer.KeyUp

        Dim currentText As String = cmbCustomer.Text
        shortList.Clear()
        cmbCustomer.Items.Clear()
        cmbCustomer.Items.Add(currentText)

        cmbCustomer.DroppedDown = True
        For Each text As String In longList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbCustomer.Text.ToUpper()) Then
                shortList.Add(text)
            End If
        Next
        cmbCustomer.Items.AddRange(shortList.ToArray())
        cmbCustomer.SelectionStart = cmbCustomer.Text.Length
        Cursor.Current = Cursors.Default
    End Sub


End Class