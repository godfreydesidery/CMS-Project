Imports Devart.Data.MySql
Imports Microsoft.Office.Interop

Public Class frmCorporateCustomers
    Dim RECORD_MODE As String = ""
    Private Function clearFields()
        txtNo.Text = ""
        cmbName.SelectedItem = Nothing
        cmbName.Text = ""
        txtContactName.Text = ""
        txtTin.Text = ""
        txtVrn.Text = ""
        txtBankAccountName.Text = ""
        txtBankAddress.Text = ""
        txtBankPostCode.Text = ""
        txtBankName.Text = ""
        txtBankAccountNo.Text = ""
        txtPostAddress.Text = ""
        txtPhysicalAddress.Text = ""
        txtPostCode.Text = ""
        txtTelephone.Text = ""
        txtMobile.Text = ""
        txtEmail.Text = ""
        txtFax.Text = ""
        Return vbNull
    End Function
    Private Function lock()
        'txtSupplierCode.ReadOnly = True
        cmbName.Enabled = False
        txtContactName.ReadOnly = True
        txtTin.ReadOnly = True
        txtVrn.ReadOnly = True
        txtBankAccountName.ReadOnly = True
        txtBankAddress.ReadOnly = True
        txtBankPostCode.ReadOnly = True
        txtBankName.ReadOnly = True
        txtBankAccountNo.ReadOnly = True
        txtPostAddress.ReadOnly = True
        txtPhysicalAddress.ReadOnly = True
        txtPostCode.ReadOnly = True
        txtTelephone.ReadOnly = True
        txtMobile.ReadOnly = True
        txtEmail.ReadOnly = True
        txtFax.ReadOnly = True
        Return vbNull
    End Function
    Private Function unlock()
        'txtSupplierCode.ReadOnly = False
        cmbName.Enabled = True
        txtContactName.ReadOnly = False
        txtTin.ReadOnly = False
        txtVrn.ReadOnly = False
        txtBankAccountName.ReadOnly = False
        txtBankAddress.ReadOnly = False
        txtBankPostCode.ReadOnly = False
        txtBankName.ReadOnly = False
        txtBankAccountNo.ReadOnly = False
        txtPostAddress.ReadOnly = False
        txtPostCode.ReadOnly = False
        txtPhysicalAddress.ReadOnly = False
        txtTelephone.ReadOnly = False
        txtMobile.ReadOnly = False
        txtEmail.ReadOnly = False
        txtFax.ReadOnly = False
        Return vbNull
    End Function
    Private Function getValues()
        Dim customer As New CorporateCustomer

        customer.GL_CUSTOMER_CODE = txtNo.Text
        customer.GL_CUSTOMER_NAME = cmbName.Text
        customer.GL_CONTACT_NAME = txtContactName.Text
        customer.GL_TIN = txtTin.Text
        customer.GL_VRN = txtVrn.Text
        customer.GL_BANK_ACC_NAME = txtBankAccountName.Text
        customer.GL_BANK_ACC_ADDRESS = txtBankAddress.Text
        customer.GL_BANK_POST_CODE = txtBankPostCode.Text
        customer.GL_BANK_NAME = txtBankName.Text
        customer.GL_BANK_ACC_NO = txtBankAccountNo.Text
        customer.GL_ADDRESS = txtPostAddress.Text
        customer.GL_POSTAL_CODE = txtPostCode.Text
        customer.GL_PHYSICAL_ADDRESS = txtPhysicalAddress.Text
        customer.GL_TELEPHONE = txtTelephone.Text
        customer.GL_MOBILE = txtMobile.Text
        customer.GL_EMAIL = txtEmail.Text
        customer.GL_FAX = txtFax.Text
        customer.GL_INVOICE_LIMIT = txtInvoiceLimit.Text
        customer.GL_CREDIT_LIMIT = txtCreditLimit.Text

        Return vbNull
    End Function
    Private Function setValues()

        Return vbNull
    End Function
    Private Function saveNew() As Boolean
        Dim saved As Boolean = False
        Dim customer As New CorporateCustomer
        If validateFields() = True Then
            'continues with operation
        Else
            'exit from the operation
            'if fields are not valid
            Return saved
            Exit Function
        End If
        Dim status As String = "ACTIVE"
        If chkActive.Checked = False Then
            status = "INACTIVE"
        End If
        If customer.addCustomer(txtNo.Text, cmbName.Text, txtPostAddress.Text, txtPostCode.Text, txtPhysicalAddress.Text, txtContactName.Text, txtBankAccountName.Text, txtBankAddress.Text, txtBankPostCode.Text, txtBankName.Text, txtBankAccountNo.Text, txtTelephone.Text, txtMobile.Text, txtEmail.Text, txtFax.Text, txtTin.Text, txtVrn.Text, Val(LCurrency.getValue(txtInvoiceLimit.Text)), Val(LCurrency.getValue(txtCreditLimit.Text)), status) = True Then
            saved = True
        End If
        Return saved
    End Function
    Private Function saveExisting() As Boolean
        Dim saved As Boolean = False
        Dim status As String = "ACTIVE"
        If chkActive.Checked = False Then
            status = "INACTIVE"
        End If

        Dim customer As New CorporateCustomer
        If validateFields() = True Then
            'continues with operation
        Else
            'exit from the operation
            'if fields are not valid
            Return saved
            Exit Function

        End If

        If customer.editCustomer(txtNo.Text, cmbName.Text, txtPostAddress.Text, txtPostCode.Text, txtPhysicalAddress.Text, txtContactName.Text, txtBankAccountName.Text, txtBankAddress.Text, txtBankPostCode.Text, txtBankName.Text, txtBankAccountNo.Text, txtTelephone.Text, txtMobile.Text, txtEmail.Text, txtFax.Text, txtTin.Text, txtVrn.Text, Val(LCurrency.getValue(txtInvoiceLimit.Text)), Val(LCurrency.getValue(txtCreditLimit.Text)), status.ToString) = True Then
            saved = True
        End If
        Return saved
    End Function
    Private Function validateFields() As Boolean
        Dim valid As Boolean = True
        Dim error_ As String = ""
        If txtNo.Text = "" Then
            valid = False
            error_ = "Customer code required"
        End If
        If cmbName.Text = "" Then
            valid = False
            error_ = "Customer name required"
        End If

        If txtTin.Text = "" Then
            valid = False
            error_ = "Customer TIN required"
        End If
        If txtVrn.Text = "" Then
            valid = False
            error_ = "Customer VRN required"
        End If
        If valid = False Then
            MsgBox("Operation failed. " + error_, vbOKOnly + vbCritical, "Error: Invalid input")
        End If
        Return valid
    End Function
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Public Shared GLOBAL_CUSTOMER_CODE As String = ""


    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        RECORD_MODE = "NEW"
        dtgrdCustomerList.Enabled = False
        clearFields() 'clear the fields
        txtNo.ReadOnly = False
        btnDelete.Enabled = False
        btnSearch.Enabled = False
        btnSave.Enabled = True
        REC_PRESENT = False
        unlock()
    End Sub
    Private Function search(customerCode As String, customerName As String)
        If customerCode = "" Then
            If customerName <> "" Then
                customerCode = (New CorporateCustomer).getCustomerCode("", customerName)
            End If
        End If
        'If txtSupplierCode.Text = "" Then
        '    MsgBox("Search field is empty. Enter Supplier code or Supplier name", vbOKOnly + vbCritical, "Error")
        '    Return vbNull
        '    Exit Function
        'End If
        If customerCode = "" Then
            'no search information provided
            MsgBox("No matching customer", vbOKOnly + vbCritical, "Error")
            'discard operation
            Return vbNull
            Exit Function
        End If
        Dim customer As New CorporateCustomer
        If customer.search(customerCode) = True Then
            'get values
            txtNo.Text = customer.GL_CUSTOMER_CODE
            cmbName.Text = customer.GL_CUSTOMER_NAME
            txtContactName.Text = customer.GL_CONTACT_NAME
            txtTin.Text = customer.GL_TIN
            txtVrn.Text = customer.GL_VRN
            txtBankAccountName.Text = customer.GL_BANK_ACC_NAME
            txtBankAddress.Text = customer.GL_BANK_ACC_ADDRESS
            txtBankPostCode.Text = customer.GL_BANK_POST_CODE
            txtBankName.Text = customer.GL_BANK_NAME
            txtBankAccountNo.Text = customer.GL_BANK_ACC_NO
            txtPostAddress.Text = customer.GL_ADDRESS
            txtPostCode.Text = customer.GL_POSTAL_CODE
            txtPhysicalAddress.Text = customer.GL_PHYSICAL_ADDRESS
            txtTelephone.Text = customer.GL_TELEPHONE
            txtMobile.Text = customer.GL_MOBILE
            txtEmail.Text = customer.GL_EMAIL
            txtFax.Text = customer.GL_FAX
            If customer.GL_STATUS = "INACTIVE" Then
                chkActive.Checked = False
            Else
                chkActive.Checked = True
            End If

            dtgrdCustomerList.Enabled = True
            btnDelete.Enabled = True
            txtNo.ReadOnly = True
            RECORD_MODE = ""
            lock()
            REC_PRESENT = True
        Else
            MsgBox("The requested record could not be found", vbOKOnly + vbCritical, "Error: Not found")
        End If

        Return vbNull
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search(txtNo.Text, cmbName.Text)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If RECORD_MODE = "NEW" Then

            If saveNew() = True Then
                'record saved successifuly
                dtgrdCustomerList.Enabled = True
                RECORD_MODE = ""
                refreshList()
                REC_PRESENT = True
                MsgBox("New customer record created successifully", vbOKOnly + vbInformation, "Success: Supplier created")

            Else
                'record could not be saved
            End If
        Else
            If saveExisting() = True Then
                'record saved successifully
                dtgrdCustomerList.Enabled = True
                refreshList()
                REC_PRESENT = True
                MsgBox("Customer record modified successifully", vbOKOnly + vbInformation, "Success: Edit supplier")
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
            txtNo.ReadOnly = False
            btnSave.Enabled = False
        Else
            txtNo.ReadOnly = True
            btnSave.Enabled = True
        End If
        dtgrdCustomerList.Enabled = True
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
        Dim customer As New CorporateCustomer
        If customer.deleteCustomer(customer.getCustomerID(txtNo.Text, "")) = True Then
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

    Private Sub txtno_TextChanged(sender As Object, e As EventArgs) Handles txtNo.TextChanged
        If txtNo.Text.Contains("'") Then
            txtNo.Text = ""
        End If
    End Sub
    Private Sub txtNo_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search(txtNo.Text, cmbName.Text)
        End If
    End Sub
    Private Sub txtNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNo.KeyDown
        If Keys.KeyCode = Keys.Down Then
            cmbName.Focus()
        End If

    End Sub

    Private Sub txtSupplierName_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtSupplierName_KeyDown(sender As Object, e As KeyEventArgs)
        If Keys.KeyCode = Keys.Down Then
            txtContactName.Focus()
        End If

    End Sub

    Private Sub txtContactName_TextChanged(sender As Object, e As EventArgs) Handles txtContactName.TextChanged
        If txtContactName.Text.Contains("'") Then
            txtContactName.Text = ""
        End If
    End Sub

    Private Sub txtContactName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContactName.KeyDown
        If Keys.KeyCode = Keys.Down Then
            txtTin.Focus()
        End If

    End Sub

    Private Sub txtTIN_TextChanged(sender As Object, e As EventArgs) Handles txtTin.TextChanged
        If txtTin.Text.Contains("'") Then
            txtTin.Text = ""
        End If
    End Sub

    Private Sub txtTIN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTin.KeyDown
        If Keys.KeyCode = Keys.Down Then
            txtVrn.Focus()
        End If

    End Sub

    Private Sub frmSuppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearFields()
        refreshList()
        Dim customer As New CorporateCustomer
        longList = customer.getCustomers("")
    End Sub
    Private Function refreshList()
        dtgrdCustomerList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `customer_id`, `customer_code`, `customer_name`, `contact_name`, `status` FROM `corporate_customers` "
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim customerId As String = ""
            Dim customerCode As String = ""
            Dim customerName As String = ""
            Dim contactName As String = ""
            Dim status As String = ""

            While reader.Read

                customerId = reader.GetString("customer_id")
                customerCode = reader.GetString("customer_code")
                customerName = reader.GetString("customer_name")
                contactName = reader.GetString("contact_name")
                status = reader.GetString("status")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = customerId
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = customerCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = customerName
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = contactName
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = status
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCustomerList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



        Return vbNull
    End Function

    Private Sub dtgrdSuppliers_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdCustomerList.RowHeaderMouseClick
        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            row = dtgrdCustomerList.CurrentRow.Index
            col = dtgrdCustomerList.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try
        Dim customerCode As String = ""
        row = dtgrdCustomerList.CurrentRow.Index
        customerCode = dtgrdCustomerList.Item(1, row).Value.ToString
        search(customerCode, "")
    End Sub



    Dim file As String = "C:\Corporate Customers.xls"


    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)
    Private Sub cmbDescription_KeyUp(sender As Object, e As EventArgs) Handles cmbName.KeyUp

        Dim currentText As String = cmbName.Text
        shortList.Clear()
        cmbName.Items.Clear()
        cmbName.Items.Add(currentText)

        cmbName.DroppedDown = True
        For Each text As String In longList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbName.Text.ToUpper()) Then
                shortList.Add(text)
            End If
        Next
        cmbName.Items.AddRange(shortList.ToArray())
        cmbName.SelectionStart = cmbName.Text.Length
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmbName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbName.SelectedIndexChanged
        If cmbName.Text.Contains("'") Then
            cmbName.Text = ""
        End If
    End Sub

    Private Sub txtVRN_TextChanged(sender As Object, e As EventArgs) Handles txtVrn.TextChanged
        If txtVrn.Text.Contains("'") Then
            txtVrn.Text = ""
        End If
    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtPostAddress.TextChanged
        If txtPostAddress.Text.Contains("'") Then
            txtPostAddress.Text = ""
        End If
    End Sub

    Private Sub txtPostCode_TextChanged(sender As Object, e As EventArgs) Handles txtPostCode.TextChanged
        If txtPostCode.Text.Contains("'") Then
            txtPostCode.Text = ""
        End If
    End Sub

    Private Sub txtPhysicalAdrress_TextChanged(sender As Object, e As EventArgs) Handles txtPhysicalAddress.TextChanged
        If txtPhysicalAddress.Text.Contains("'") Then
            txtPhysicalAddress.Text = ""
        End If
    End Sub

    Private Sub dtgrdCustomerList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdCustomerList.CellContentClick

    End Sub
End Class