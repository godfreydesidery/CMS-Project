Imports Devart.Data.MySql
Imports Microsoft.Office.Interop

Public Class frmSuppliers
    Dim RECORD_MODE As String = ""
    Private Function clearFields()
        txtSupplierCode.Text = ""
        cmbSupplierName.SelectedItem = Nothing
        cmbSupplierName.Text = ""
        txtContactName.Text = ""
        txtTIN.Text = ""
        txtVRN.Text = ""
        txtBankAccName.Text = ""
        txtBankAccAddress.Text = ""
        txtBankPostCode.Text = ""
        txtBankName.Text = ""
        txtBankAccNo.Text = ""
        txtAddress.Text = ""
        txtPostCode.Text = ""
        txtPhysicalAdrress.Text = ""
        txtTelephone.Text = ""
        txtMobile.Text = ""
        txtEmail.Text = ""
        txtFax.Text = ""
        Return vbNull
    End Function
    Private Function lock()
        'txtSupplierCode.ReadOnly = True
        cmbSupplierName.Enabled = False
        txtContactName.ReadOnly = True
        txtTIN.ReadOnly = True
        txtVRN.ReadOnly = True
        txtBankAccName.ReadOnly = True
        txtBankAccAddress.ReadOnly = True
        txtBankPostCode.ReadOnly = True
        txtBankName.ReadOnly = True
        txtBankAccNo.ReadOnly = True
        txtAddress.ReadOnly = True
        txtPostCode.ReadOnly = True
        txtPhysicalAdrress.ReadOnly = True
        txtTelephone.ReadOnly = True
        txtMobile.ReadOnly = True
        txtEmail.ReadOnly = True
        txtFax.ReadOnly = True
        Return vbNull
    End Function
    Private Function unlock()
        'txtSupplierCode.ReadOnly = False
        cmbSupplierName.Enabled = True
        txtContactName.ReadOnly = False
        txtTIN.ReadOnly = False
        txtVRN.ReadOnly = False
        txtBankAccName.ReadOnly = False
        txtBankAccAddress.ReadOnly = False
        txtBankPostCode.ReadOnly = False
        txtBankName.ReadOnly = False
        txtBankAccNo.ReadOnly = False
        txtAddress.ReadOnly = False
        txtPostCode.ReadOnly = False
        txtPhysicalAdrress.ReadOnly = False
        txtTelephone.ReadOnly = False
        txtMobile.ReadOnly = False
        txtEmail.ReadOnly = False
        txtFax.ReadOnly = False
        Return vbNull
    End Function
    Private Function getValues()
        Dim supplier As New Supplier

        supplier.GL_SUPPLIER_CODE = txtSupplierCode.Text
        supplier.GL_SUPPLIER_NAME = cmbSupplierName.Text
        supplier.GL_CONTACT_NAME = txtContactName.Text
        supplier.GL_TIN = txtTIN.Text
        supplier.GL_VRN = txtVRN.Text
        supplier.GL_BANK_ACC_NAME = txtBankAccName.Text
        supplier.GL_BANK_ACC_ADDRESS = txtBankAccAddress.Text
        supplier.GL_BANK_POST_CODE = txtBankPostCode.Text
        supplier.GL_BANK_NAME = txtBankName.Text
        supplier.GL_BANK_ACC_NO = txtBankAccNo.Text
        supplier.GL_ADDRESS = txtAddress.Text
        supplier.GL_POSTAL_CODE = txtPostCode.Text
        supplier.GL_PHYSICAL_ADDRESS = txtPhysicalAdrress.Text
        supplier.GL_TELEPHONE = txtTelephone.Text
        supplier.GL_MOBILE = txtMobile.Text
        supplier.GL_EMAIL = txtEmail.Text
        supplier.GL_FAX = txtFax.Text

        Return vbNull
    End Function
    Private Function setValues()

        Return vbNull
    End Function
    Private Function saveNew() As Boolean
        Dim saved As Boolean = False
        Dim supplier As New Supplier
        If validateFields() = True Then
            'continues with operation
        Else
            'exit from the operation
            'if fields are not valid
            Return saved
            Exit Function
        End If
        If (supplier.addSupplier(txtSupplierCode.Text, cmbSupplierName.Text, txtAddress.Text, txtPostCode.Text, txtPhysicalAdrress.Text, txtContactName.Text, txtBankAccName.Text, txtBankAccAddress.Text, txtBankPostCode.Text, txtBankName.Text, txtBankAccNo.Text, txtTelephone.Text, txtMobile.Text, txtEmail.Text, txtFax.Text, txtTIN.Text, txtVRN.Text)) = True Then
            saved = True
        End If
        Return saved
    End Function
    Private Function saveExisting() As Boolean
        Dim saved As Boolean = False
        Dim supplier As New Supplier
        If validateFields() = True Then
            'continues with operation
        Else
            'exit from the operation
            'if fields are not valid
            Return saved
            Exit Function
        End If
        If (supplier.editSupplier(supplier.getSupplierID(txtSupplierCode.Text, ""), txtSupplierCode.Text, cmbSupplierName.Text, txtAddress.Text, txtPostCode.Text, txtPhysicalAdrress.Text, txtContactName.Text, txtBankAccName.Text, txtBankAccAddress.Text, txtBankPostCode.Text, txtBankName.Text, txtBankAccNo.Text, txtTelephone.Text, txtMobile.Text, txtEmail.Text, txtFax.Text, txtTIN.Text, txtVRN.Text)) = True Then
            saved = True
        End If
        Return saved
    End Function
    Private Function validateFields() As Boolean
        Dim valid As Boolean = True
        Dim error_ As String = ""
        If txtSupplierCode.Text = "" Then
            valid = False
            error_ = "Supplier code required"
        End If
        If cmbSupplierName.Text = "" Then
            valid = False
            error_ = "Supplier Company name required"
        End If
        If txtContactName.Text = "" Then
            valid = False
            error_ = "Supplier Contact name required"
        End If
        If txtTIN.Text = "" Then
            valid = False
            error_ = "Supplier TIN required"
        End If
        If txtVRN.Text = "" Then
            valid = False
            error_ = "Supplier VRN required"
        End If
        If valid = False Then
            MsgBox("Operation failed. " + error_, vbOKOnly + vbCritical, "Error: Invalid input")
        End If
        Return valid
    End Function
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Public Shared GLOBAL_SUPPLIER_CODE As String = ""
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnProductAndService.Click
        If txtSupplierCode.Text <> "" Then
            Dim supcode As String = txtSupplierCode.Text
            GLOBAL_SUPPLIER_CODE = supcode
            frmSupplierService.ShowDialog()
        Else
            MsgBox("No selection. Please Select a supplier", vbOKOnly + vbCritical, "Error: No selection")
        End If

    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        RECORD_MODE = "NEW"
        btnProductAndService.Enabled = False
        dtgrdSuppliers.Enabled = False
        clearFields() 'clear the fields
        txtSupplierCode.ReadOnly = False
        btnDelete.Enabled = False
        btnSearch.Enabled = False
        btnSave.Enabled = True
        REC_PRESENT = False
        unlock()
    End Sub
    Private Function search(supplierCode As String, supplierName As String)
        If supplierCode = "" Then
            If supplierName <> "" Then
                supplierCode = (New Supplier).getSupplierCode("", supplierName)
            End If
        End If
        'If txtSupplierCode.Text = "" Then
        '    MsgBox("Search field is empty. Enter Supplier code or Supplier name", vbOKOnly + vbCritical, "Error")
        '    Return vbNull
        '    Exit Function
        'End If
        If supplierCode = "" Then
            'no search information provided
            MsgBox("No matching supplier", vbOKOnly + vbCritical, "Error")
            'discard operation
            Return vbNull
            Exit Function
        End If
        Dim supplier As New Supplier
        If supplier.search(supplierCode) = True Then
            'get values
            txtSupplierCode.Text = supplier.GL_SUPPLIER_CODE
            cmbSupplierName.Text = supplier.GL_SUPPLIER_NAME
            txtContactName.Text = supplier.GL_CONTACT_NAME
            txtTIN.Text = supplier.GL_TIN
            txtVRN.Text = supplier.GL_VRN
            txtBankAccName.Text = supplier.GL_BANK_ACC_NAME
            txtBankAccAddress.Text = supplier.GL_BANK_ACC_ADDRESS
            txtBankPostCode.Text = supplier.GL_BANK_POST_CODE
            txtBankName.Text = supplier.GL_BANK_NAME
            txtBankAccNo.Text = supplier.GL_BANK_ACC_NO
            txtAddress.Text = supplier.GL_ADDRESS
            txtPostCode.Text = supplier.GL_POSTAL_CODE
            txtPhysicalAdrress.Text = supplier.GL_PHYSICAL_ADDRESS
            txtTelephone.Text = supplier.GL_TELEPHONE
            txtMobile.Text = supplier.GL_MOBILE
            txtEmail.Text = supplier.GL_EMAIL
            txtFax.Text = supplier.GL_FAX


            btnProductAndService.Enabled = True
            dtgrdSuppliers.Enabled = True
            btnDelete.Enabled = True
            txtSupplierCode.ReadOnly = True
            RECORD_MODE = ""
            lock()
            REC_PRESENT = True
        Else
            MsgBox("The requested record could not be found", vbOKOnly + vbCritical, "Error: Not found")
        End If

        Return vbNull
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search(txtSupplierCode.Text, cmbSupplierName.Text)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If RECORD_MODE = "NEW" Then

            If saveNew() = True Then
                'record saved successifuly
                dtgrdSuppliers.Enabled = True
                btnProductAndService.Enabled = True
                RECORD_MODE = ""
                refreshList()
                REC_PRESENT = True
                MsgBox("New supplier record created successifully", vbOKOnly + vbInformation, "Success: Supplier created")

            Else
                'record could not be saved
            End If
        Else
            If saveExisting() = True Then
                'record saved successifully
                dtgrdSuppliers.Enabled = True
                btnProductAndService.Enabled = True
                refreshList()
                REC_PRESENT = True
                MsgBox("Supplier record modified successifully", vbOKOnly + vbInformation, "Success: Edit supplier")
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
            txtSupplierCode.ReadOnly = False
            btnSave.Enabled = False
        Else
            txtSupplierCode.ReadOnly = True
            btnSave.Enabled = True
        End If
        dtgrdSuppliers.Enabled = True
        'clearFields()
        unlock()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected supplier? All information about the supplier will be removed from the system. This action can not be undone.", vbYesNo + vbQuestion, "Delete Supplier")
        If res = DialogResult.Yes Then
            'proceed
        Else
            'discard operation
            Exit Sub
        End If
        Dim supplier As New Supplier
        If supplier.deleteSupplier(supplier.getSupplierID(txtSupplierCode.Text, "")) = True Then
            btnDelete.Enabled = False
            btnProductAndService.Enabled = False
            'dtgrdSuppliers.Enabled = False
            clearFields() 'clear the fields
            refreshList()
            REC_PRESENT = False
            MsgBox("Supplier record deleted successifully", vbOKOnly + vbInformation, "Success: Delete supplier record")
        Else
            MsgBox("Could not delete the selected supplier record", vbOKOnly + vbCritical, "Error: Delete failed")
        End If

    End Sub

    Private Sub txtSupplierCode_TextChanged(sender As Object, e As EventArgs) Handles txtSupplierCode.TextChanged

    End Sub
    Private Sub txtSupplierCode_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtSupplierCode.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search(txtSupplierCode.Text, cmbSupplierName.Text)
        End If
    End Sub
    Private Sub txtSupplierCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupplierCode.KeyDown
        If Keys.KeyCode = Keys.Down Then
            cmbSupplierName.Focus()
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

    End Sub

    Private Sub txtContactName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContactName.KeyDown
        If Keys.KeyCode = Keys.Down Then
            txtTIN.Focus()
        End If

    End Sub

    Private Sub txtTIN_TextChanged(sender As Object, e As EventArgs) Handles txtTIN.TextChanged

    End Sub

    Private Sub txtTIN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN.KeyDown
        If Keys.KeyCode = Keys.Down Then
            txtVRN.Focus()
        End If

    End Sub

    Private Sub frmSuppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearFields()
        refreshList()
        Dim supplier As New Supplier
        longList = supplier.getSuppliers("")
    End Sub
    Private Function refreshList()
        dtgrdSuppliers.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `supplier_id`, `supplier_code`, `supplier_name`, `contact_name` FROM `supplier` "
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim supplierCode As String = ""
            Dim supplierName As String = ""
            Dim contactName As String = ""

            While reader.Read

                supplierCode = reader.GetString("supplier_code")
                supplierName = reader.GetString("supplier_name")
                contactName = reader.GetString("contact_name")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = supplierCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = supplierName
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = contactName
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdSuppliers.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



        Return vbNull
    End Function

    Private Sub dtgrdSuppliers_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdSuppliers.RowHeaderMouseClick
        btnProductAndService.Enabled = False
        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            row = dtgrdSuppliers.CurrentRow.Index
            col = dtgrdSuppliers.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try
        Dim supplierCode As String = ""
        row = dtgrdSuppliers.CurrentRow.Index
        supplierCode = dtgrdSuppliers.Item(0, row).Value.ToString
        search(supplierCode, "")
        btnProductAndService.Enabled = True
    End Sub

    Private Sub dtgrdSuppliers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdSuppliers.CellContentClick

    End Sub


    Dim file As String = "C:\suppliers.xls"


    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)
    Private Sub cmbDescription_KeyUp(sender As Object, e As EventArgs) Handles cmbSupplierName.KeyUp

        Dim currentText As String = cmbSupplierName.Text
        shortList.Clear()
        cmbSupplierName.Items.Clear()
        cmbSupplierName.Items.Add(currentText)

        cmbSupplierName.DroppedDown = True
        For Each text As String In longList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbSupplierName.Text.ToUpper()) Then
                shortList.Add(text)
            End If
        Next
        cmbSupplierName.Items.AddRange(shortList.ToArray())
        cmbSupplierName.SelectionStart = cmbSupplierName.Text.Length
        Cursor.Current = Cursors.Default
    End Sub

End Class