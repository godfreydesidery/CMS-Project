Imports Devart.Data.MySql
Imports Microsoft.Office.Interop

Public Class frmMassManager
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub frmMassManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Dim path As String = ""
    Dim count As Integer = 0
    Dim itemMasterAttributes = New String() {"ITEM_CODE", "PRIMARY_SCAN_CODE", "DESCR", "SHORT_DESCR", "PACK_SIZE", "DEPT", "DEPT_NAME", "CLASS", "CLASS_NAME", "SUB_CLASS", "SUB_CLASS_NAME", "SUPPLIER", "SUPPLIER_NAME", "CPRICE_VAT_EXCL", "VAT", "CPRICE_VAT_INCL", "MARGIN", "DISC", "SPRICE", "STOCK", "MIN_STOCK", "MAX_STOCK", "REORDER_LEVEL", "UOM"}
    Dim supplierMasterAttributes = New String() {"SUPPLIER_CODE", "SUPPLIER_NAME", "ADDRESS", "POST_CODE", "PHYSICAL_ADDRESS", "CONTACT_NAME", "BANK_ACC_NAME", "BANK_ACC_ADDRESS", "BANK_POST_CODE", "BANK_NAME", "BANK_ACC_NO", "TELEPHONE", "MOBILE", "EMAIL", "FAX", "TIN", "VRN", "NOTES"}
    Dim unitsAttributes = New String() {"DEPT", "DEPT_NAME", "CLASS", "CLASS_NAME", "SUB_CLASS", "SUB_CLASS_NAME"}

    Private Function validateFileFormat(path As String)
        Dim valid As Boolean = False

        valid = True

        Return valid
    End Function
    Private Function validateUnitMasterFormat(path As String)
        Dim valid As Boolean = False
        lblOperation.Text = "Validating file... please wait"
        Try
            Dim objXLApp As Microsoft.Office.Interop.Excel.Application
            Dim objXLWb As Excel.Workbook
            Dim objXLWs As Excel.Worksheet
            Dim count As Integer = 0
            objXLApp = New Excel.Application
            objXLApp.Workbooks.Open(path)

            objXLWb = objXLApp.Workbooks(1)
            objXLWs = objXLWb.Worksheets(1)

            valid = True

            If objXLWs.Range("A" & 1).Value.ToString <> unitsAttributes(0) Then
                valid = False
            End If
            If objXLWs.Range("B" & 1).Value.ToString <> unitsAttributes(1) Then
                valid = False
            End If
            If objXLWs.Range("C" & 1).Value.ToString <> unitsAttributes(2) Then
                valid = False
            End If
            If objXLWs.Range("D" & 1).Value.ToString <> unitsAttributes(3) Then
                valid = False
            End If
            If objXLWs.Range("E" & 1).Value.ToString <> unitsAttributes(4) Then
                valid = False
            End If
            If objXLWs.Range("F" & 1).Value.ToString <> unitsAttributes(5) Then
                valid = False
            End If
            lblOperation.Text = ""
            objXLApp.Quit()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
            valid = False
        End Try
        lblOperation.Text = ""
        Return valid
    End Function
    Private Sub btnUploadUnitMaster_Click(sender As Object, e As EventArgs) Handles btnuploadUnits.Click
        path = ""
        count = 0
        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateunitMasterFormat(path) = True Then
                count = getRecordCount(path)

                Dim objXLApp As Excel.Application
                Dim objXLWb As Excel.Workbook
                Dim objXLWs As Excel.Worksheet

                objXLApp = New Excel.Application
                objXLApp.Workbooks.Open(path)
                objXLWb = objXLApp.Workbooks(1)
                objXLWs = objXLWb.Worksheets(1)

                Try
                    prgBar.Value = 0
                    lblOperation.Text = "Uploading departments... please wait"
                    For i As Integer = 2 To count
                        showProgress(i, count)
                        'upload items

                        Dim dept_code As String = objXLWs.Range("A" & i).Value
                        Dim dept_name As String = objXLWs.Range("B" & i).Value
                        Dim class_code As String = objXLWs.Range("C" & i).Value
                        Dim class_name As String = objXLWs.Range("D" & i).Value
                        Dim sub_class_code As String = objXLWs.Range("E" & i).Value
                        Dim sub_class_name As String = objXLWs.Range("F" & i).Value

                        Dim conn As New MySqlConnection(Database.conString)
                        conn.Open()
                        Dim command As New MySqlCommand()
                        command.Connection = conn
                        command.CommandText = "INSERT IGNORE INTO `department`(`department_name`) VALUES (@department_name)"
                        command.Prepare()
                        command.Parameters.AddWithValue("@department_name", dept_name)
                        command.ExecuteNonQuery()
                        conn.Close()
                    Next
                    lblOperation.Text = ""
                    lblOperation.Text = "Uploading classes... please wait"
                    For i As Integer = 2 To count
                        showProgress(i, count)
                        'upload items

                        Dim dept_code As String = objXLWs.Range("A" & i).Value
                        Dim dept_name As String = objXLWs.Range("B" & i).Value
                        Dim class_code As String = objXLWs.Range("C" & i).Value
                        Dim class_name As String = objXLWs.Range("D" & i).Value
                        Dim sub_class_code As String = objXLWs.Range("E" & i).Value
                        Dim sub_class_name As String = objXLWs.Range("F" & i).Value

                        Dim conn As New MySqlConnection(Database.conString)
                        conn.Open()
                        Dim command As New MySqlCommand()
                        command.Connection = conn
                        command.CommandText = "INSERT IGNORE INTO `class`(`class_name`, `department_id`) VALUES (@class_name,@dept_id)"
                        command.Prepare()
                        command.Parameters.AddWithValue("@class_name", class_name)
                        command.Parameters.AddWithValue("@dept_id", (New Class_).getDepartmentID(dept_name))
                        command.ExecuteNonQuery()
                        conn.Close()

                    Next
                    lblOperation.Text = ""
                    lblOperation.Text = "Uploading sub classes... please wait"
                    For i As Integer = 2 To count
                        showProgress(i, count)
                        'upload items

                        Dim dept_code As String = objXLWs.Range("A" & i).Value
                        Dim dept_name As String = objXLWs.Range("B" & i).Value
                        Dim class_code As String = objXLWs.Range("C" & i).Value
                        Dim class_name As String = objXLWs.Range("D" & i).Value
                        Dim sub_class_code As String = objXLWs.Range("E" & i).Value
                        Dim sub_class_name As String = objXLWs.Range("F" & i).Value

                        Dim conn As New MySqlConnection(Database.conString)
                        conn.Open()
                        Dim command As New MySqlCommand()
                        command.Connection = conn
                        command.CommandText = "INSERT IGNORE INTO `sub_class`(`sub_class_name`, `class_id`) VALUES (@sub_class_name,@class_id)"
                        command.Prepare()
                        command.Parameters.AddWithValue("@sub_class_name", sub_class_name)
                        command.Parameters.AddWithValue("@class_id", (New SubClass).getClassID(class_name))
                        command.ExecuteNonQuery()
                        conn.Close()
                    Next
                    lblOperation.Text = ""
                    MsgBox("Operation completed")
                    prgBar.Value = 0
                Catch ex As Exception
                    MsgBox(ex.StackTrace)
                End Try
                objXLApp.Quit()


            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
    End Sub
    Private Sub btnUpdateUnitMaster_Click(sender As Object, e As EventArgs) Handles btnUpdateUnits.Click
        path = ""
        count = 0
        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateUnitMasterFormat(path) = True Then
                count = getRecordCount(path)

                Dim objXLApp As Excel.Application
                Dim objXLWb As Excel.Workbook
                Dim objXLWs As Excel.Worksheet

                objXLApp = New Excel.Application
                objXLApp.Workbooks.Open(path)
                objXLWb = objXLApp.Workbooks(1)
                objXLWs = objXLWb.Worksheets(1)

                Try
                    prgBar.Value = 0
                    lblOperation.Text = "Updating departments... please wait"
                    For i As Integer = 2 To count
                        showProgress(i, count)
                        'upload items

                        Dim dept_code As String = objXLWs.Range("A" & i).Value
                        Dim dept_name As String = objXLWs.Range("B" & i).Value
                        Dim class_code As String = objXLWs.Range("C" & i).Value
                        Dim class_name As String = objXLWs.Range("D" & i).Value
                        Dim sub_class_code As String = objXLWs.Range("E" & i).Value
                        Dim sub_class_name As String = objXLWs.Range("F" & i).Value

                        Dim conn As New MySqlConnection(Database.conString)
                        conn.Open()
                        Dim command As New MySqlCommand()
                        command.Connection = conn
                        command.CommandText = "UPDATE `department` SET `department_name`='" + dept_name + "' WHERE `department_name`='" + dept_name + "'"
                        command.Prepare()
                        command.ExecuteNonQuery()
                        conn.Close()
                    Next
                    lblOperation.Text = ""
                    lblOperation.Text = "Updating classes... please wait"
                    For i As Integer = 2 To count
                        showProgress(i, count)
                        'upload items

                        Dim dept_code As String = objXLWs.Range("A" & i).Value
                        Dim dept_name As String = objXLWs.Range("B" & i).Value
                        Dim class_code As String = objXLWs.Range("C" & i).Value
                        Dim class_name As String = objXLWs.Range("D" & i).Value
                        Dim sub_class_code As String = objXLWs.Range("E" & i).Value
                        Dim sub_class_name As String = objXLWs.Range("F" & i).Value

                        Dim conn As New MySqlConnection(Database.conString)
                        conn.Open()
                        Dim command As New MySqlCommand()
                        command.Connection = conn
                        command.CommandText = "UPDATE `class` SET `class_name`='" + class_name + "',`department_id`='" + (New Department).getDepartmentID(dept_name) + "' WHERE `class_name`='" + class_name + "'"
                        command.Prepare()
                        command.ExecuteNonQuery()
                        conn.Close()

                    Next
                    lblOperation.Text = ""
                    lblOperation.Text = "Updating sub classes... please wait"
                    For i As Integer = 2 To count
                        showProgress(i, count)
                        'upload items

                        Dim dept_code As String = objXLWs.Range("A" & i).Value
                        Dim dept_name As String = objXLWs.Range("B" & i).Value
                        Dim class_code As String = objXLWs.Range("C" & i).Value
                        Dim class_name As String = objXLWs.Range("D" & i).Value
                        Dim sub_class_code As String = objXLWs.Range("E" & i).Value
                        Dim sub_class_name As String = objXLWs.Range("F" & i).Value

                        Dim conn As New MySqlConnection(Database.conString)
                        conn.Open()
                        Dim command As New MySqlCommand()
                        command.Connection = conn
                        command.CommandText = "UPDATE `sub_class` SET `sub_class_name`='" + sub_class_name + "',`class_id`='" + (New Class_).getClassID(class_name) + "' WHERE `sub_class_name`='" + sub_class_name + "'"
                        command.Prepare()
                        command.ExecuteNonQuery()
                        conn.Close()
                    Next
                    lblOperation.Text = ""
                    MsgBox("Operation completed")
                    prgBar.Value = 0
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                objXLApp.Quit()


            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
    End Sub
    Private Function validateSupplierMasterFormat(path As String)
        Dim valid As Boolean = False
        lblOperation.Text = "Validating file... please wait"
        Try
            Dim objXLApp As Microsoft.Office.Interop.Excel.Application
            Dim objXLWb As Excel.Workbook
            Dim objXLWs As Excel.Worksheet
            Dim count As Integer = 0
            objXLApp = New Excel.Application
            objXLApp.Workbooks.Open(path)

            objXLWb = objXLApp.Workbooks(1)
            objXLWs = objXLWb.Worksheets(1)

            valid = True

            If objXLWs.Range("A" & 1).Value.ToString <> supplierMasterAttributes(0) Then
                valid = False
            End If
            If objXLWs.Range("B" & 1).Value.ToString <> supplierMasterAttributes(1) Then
                valid = False
            End If
            If objXLWs.Range("C" & 1).Value.ToString <> supplierMasterAttributes(2) Then
                valid = False
            End If
            If objXLWs.Range("D" & 1).Value.ToString <> supplierMasterAttributes(3) Then
                valid = False
            End If
            If objXLWs.Range("E" & 1).Value.ToString <> supplierMasterAttributes(4) Then
                valid = False
            End If
            If objXLWs.Range("F" & 1).Value.ToString <> supplierMasterAttributes(5) Then
                valid = False
            End If
            If objXLWs.Range("G" & 1).Value.ToString <> supplierMasterAttributes(6) Then
                valid = False
            End If
            If objXLWs.Range("H" & 1).Value.ToString <> supplierMasterAttributes(7) Then
                valid = False
            End If
            If objXLWs.Range("I" & 1).Value.ToString <> supplierMasterAttributes(8) Then
                valid = False
            End If
            If objXLWs.Range("J" & 1).Value.ToString <> supplierMasterAttributes(9) Then
                valid = False
            End If
            If objXLWs.Range("K" & 1).Value.ToString <> supplierMasterAttributes(10) Then
                valid = False
            End If
            If objXLWs.Range("L" & 1).Value.ToString <> supplierMasterAttributes(11) Then
                valid = False
            End If
            If objXLWs.Range("M" & 1).Value.ToString <> supplierMasterAttributes(12) Then
                valid = False
            End If
            If objXLWs.Range("N" & 1).Value.ToString <> supplierMasterAttributes(13) Then
                valid = False
            End If
            If objXLWs.Range("O" & 1).Value.ToString <> supplierMasterAttributes(14) Then
                valid = False
            End If
            If objXLWs.Range("P" & 1).Value.ToString <> supplierMasterAttributes(15) Then
                valid = False
            End If
            If objXLWs.Range("Q" & 1).Value.ToString <> supplierMasterAttributes(16) Then
                valid = False
            End If
            If objXLWs.Range("R" & 1).Value.ToString <> supplierMasterAttributes(17) Then
                valid = False
            End If
            lblOperation.Text = ""
            objXLApp.Quit()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
            valid = False
        End Try
        lblOperation.Text = ""
        Return valid
    End Function
    Private Sub btnUploadSupplierMaster_Click(sender As Object, e As EventArgs) Handles btnUploadSupplier.Click
        path = ""
        count = 0
        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateSupplierMasterFormat(path) = True Then
                count = getRecordCount(path)
                If validateMasterRecords(path) Then

                    Dim objXLApp As Excel.Application
                    Dim objXLWb As Excel.Workbook
                    Dim objXLWs As Excel.Worksheet

                    objXLApp = New Excel.Application
                    objXLApp.Workbooks.Open(path)
                    objXLWb = objXLApp.Workbooks(1)
                    objXLWs = objXLWb.Worksheets(1)

                    Try
                        prgBar.Value = 0
                        lblOperation.Text = "Uploading... please wait"
                        For i As Integer = 2 To count
                            showProgress(i, count)
                            'upload items

                            Dim supplier_code As String = objXLWs.Range("A" & i).Value
                            Dim supplier_name As String = objXLWs.Range("B" & i).Value
                            Dim address As String = objXLWs.Range("C" & i).Value
                            Dim post_code As String = objXLWs.Range("D" & i).Value
                            Dim physical_address As String = objXLWs.Range("E" & i).Value
                            Dim contact_name As String = objXLWs.Range("F" & i).Value
                            Dim bank_acc_name As String = objXLWs.Range("G" & i).Value
                            Dim bank_acc_address As String = objXLWs.Range("H" & i).Value
                            Dim bank_post_code As String = objXLWs.Range("I" & i).Value
                            Dim bank_name As String = objXLWs.Range("J" & i).Value
                            Dim bank_acc_no As String = objXLWs.Range("K" & i).Value
                            Dim telephone As String = objXLWs.Range("L" & i).Value
                            Dim mobile As String = objXLWs.Range("M" & i).Value
                            Dim email As String = objXLWs.Range("N" & i).Value
                            Dim fax As String = objXLWs.Range("O" & i).Value
                            Dim tin As String = objXLWs.Range("P" & i).Value
                            Dim vrn As String = objXLWs.Range("Q" & i).Value
                            Dim notes As String = objXLWs.Range("R" & i).Value

                            Dim conn As New MySqlConnection(Database.conString)
                            conn.Open()
                            Dim command As New MySqlCommand()
                            command.Connection = conn
                            command.CommandText = "INSERT IGNORE INTO `supplier`( `supplier_code`, `supplier_name`, `address`,`contact_name`, `telephone`, `mob`, `email`,`tin`, `vrn`) VALUES (@supplies_code,@supplier_name,@address,@contact_name,@telephone,@mobile,@email,@tin,@vrn)"
                            command.Prepare()
                            command.Parameters.AddWithValue("@supplies_code", supplier_code)
                            command.Parameters.AddWithValue("@supplier_name", supplier_name)
                            command.Parameters.AddWithValue("@address", address)
                            command.Parameters.AddWithValue("@mobile", mobile)
                            command.Parameters.AddWithValue("@email", email)
                            command.Parameters.AddWithValue("@vrn", vrn)
                            command.Parameters.AddWithValue("@telephone", telephone)
                            command.Parameters.AddWithValue("@contact_name", contact_name)
                            command.Parameters.AddWithValue("@tin", tin)
                            command.ExecuteNonQuery()
                            conn.Close()

                        Next
                        lblOperation.Text = ""
                        MsgBox("Operation completed")
                        prgBar.Value = 0
                    Catch ex As Exception
                        MsgBox(ex.StackTrace)
                    End Try
                    objXLApp.Quit()
                Else
                    MsgBox("Operation failed. Incomplete records")
                    prgBar.Value = 0
                End If

            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
    End Sub
    Private Sub btnUpdateSupplierMaster_Click(sender As Object, e As EventArgs) Handles btnUpdateSupplier.Click
        path = ""
        count = 0

        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateSupplierMasterFormat(path) = True Then
                count = getRecordCount(path)
                If validateMasterRecords(path) Then

                    Dim objXLApp As Excel.Application
                    Dim objXLWb As Excel.Workbook
                    Dim objXLWs As Excel.Worksheet

                    objXLApp = New Excel.Application
                    objXLApp.Workbooks.Open(path)
                    objXLWb = objXLApp.Workbooks(1)
                    objXLWs = objXLWb.Worksheets(1)

                    Try
                        prgBar.Value = 0
                        lblOperation.Text = "Updating... please wait"
                        For i As Integer = 2 To count
                            showProgress(i, count)
                            'update items

                            Dim supplier_code As String = objXLWs.Range("A" & i).Value
                            Dim supplier_name As String = objXLWs.Range("B" & i).Value
                            Dim address As String = objXLWs.Range("C" & i).Value
                            Dim post_code As String = objXLWs.Range("D" & i).Value
                            Dim physical_address As String = objXLWs.Range("E" & i).Value
                            Dim contact_name As String = objXLWs.Range("F" & i).Value
                            Dim bank_acc_name As String = objXLWs.Range("G" & i).Value
                            Dim bank_acc_address As String = objXLWs.Range("H" & i).Value
                            Dim bank_post_code As String = objXLWs.Range("I" & i).Value
                            Dim bank_name As String = objXLWs.Range("J" & i).Value
                            Dim bank_acc_no As String = objXLWs.Range("K" & i).Value
                            Dim telephone As String = objXLWs.Range("L" & i).Value
                            Dim mobile As String = objXLWs.Range("M" & i).Value
                            Dim email As String = objXLWs.Range("N" & i).Value
                            Dim fax As String = objXLWs.Range("O" & i).Value
                            Dim tin As String = objXLWs.Range("P" & i).Value
                            Dim vrn As String = objXLWs.Range("Q" & i).Value
                            Dim notes As String = objXLWs.Range("R" & i).Value

                            Dim conn As New MySqlConnection(Database.conString)
                            conn.Open()
                            Dim command As New MySqlCommand()
                            command.Connection = conn
                            command.CommandText = "UPDATE `supplier` SET `supplier_name`='" + supplier_name + "',`address`='" + address + "',`post_code`='" + post_code + "',`physical_address`='" + physical_address + "',`contact_name`='" + contact_name + "',`bank_acc_name`='" + bank_acc_name + "',`bank_acc_address`='" + bank_acc_address + "',`bank_post_code`='" + bank_post_code + "',`bank_name`='" + bank_name + "',`bank_acc_no`='" + bank_acc_no + "',`telephone`='" + telephone + "',`mob`='" + mobile + "',`email`='" + email + "',`fax`='" + fax + "',`tin`='" + tin + "',`vrn`='" + vrn + "' WHERE `supplier_code`='" + supplier_code + "'"
                            command.Prepare()
                            command.ExecuteNonQuery()
                            conn.Close()
                        Next
                        lblOperation.Text = ""
                        MsgBox("Operation completed")
                        prgBar.Value = 0
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    objXLApp.Quit()
                Else
                    MsgBox("Operation failed. Incomplete records")
                    prgBar.Value = 0
                End If

            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
    End Sub
    Private Function validateMasterFormat(path As String)
        Dim valid As Boolean = False
        lblOperation.Text = "Validating file... please wait"
        Try
            Dim objXLApp As Microsoft.Office.Interop.Excel.Application
            Dim objXLWb As Excel.Workbook
            Dim objXLWs As Excel.Worksheet
            Dim count As Integer = 0
            objXLApp = New Excel.Application
            objXLApp.Workbooks.Open(path)

            objXLWb = objXLApp.Workbooks(1)
            objXLWs = objXLWb.Worksheets(1)

            valid = True

            If objXLWs.Range("A" & 1).Value.ToString <> itemMasterAttributes(0) Then
                valid = False
            End If
            If objXLWs.Range("B" & 1).Value.ToString <> itemMasterAttributes(1) Then
                valid = False
            End If
            If objXLWs.Range("C" & 1).Value.ToString <> itemMasterAttributes(2) Then
                valid = False
            End If
            If objXLWs.Range("D" & 1).Value.ToString <> itemMasterAttributes(3) Then
                valid = False
            End If
            If objXLWs.Range("E" & 1).Value.ToString <> itemMasterAttributes(4) Then
                valid = False
            End If
            If objXLWs.Range("F" & 1).Value.ToString <> itemMasterAttributes(5) Then
                valid = False
            End If
            If objXLWs.Range("G" & 1).Value.ToString <> itemMasterAttributes(6) Then
                valid = False
            End If
            If objXLWs.Range("H" & 1).Value.ToString <> itemMasterAttributes(7) Then
                valid = False
            End If
            If objXLWs.Range("I" & 1).Value.ToString <> itemMasterAttributes(8) Then
                valid = False
            End If
            If objXLWs.Range("J" & 1).Value.ToString <> itemMasterAttributes(9) Then
                valid = False
            End If
            If objXLWs.Range("K" & 1).Value.ToString <> itemMasterAttributes(10) Then
                valid = False
            End If
            If objXLWs.Range("L" & 1).Value.ToString <> itemMasterAttributes(11) Then
                valid = False
            End If
            If objXLWs.Range("M" & 1).Value.ToString <> itemMasterAttributes(12) Then
                valid = False
            End If
            If objXLWs.Range("N" & 1).Value.ToString <> itemMasterAttributes(13) Then
                valid = False
            End If
            If objXLWs.Range("O" & 1).Value.ToString <> itemMasterAttributes(14) Then
                valid = False
            End If
            If objXLWs.Range("P" & 1).Value.ToString <> itemMasterAttributes(15) Then
                valid = False
            End If
            If objXLWs.Range("Q" & 1).Value.ToString <> itemMasterAttributes(16) Then
                valid = False
            End If
            If objXLWs.Range("R" & 1).Value.ToString <> itemMasterAttributes(17) Then
                valid = False
            End If
            If objXLWs.Range("S" & 1).Value.ToString <> itemMasterAttributes(18) Then
                valid = False
            End If
            If objXLWs.Range("T" & 1).Value.ToString <> itemMasterAttributes(19) Then
                valid = False
            End If
            If objXLWs.Range("U" & 1).Value.ToString <> itemMasterAttributes(20) Then
                valid = False
            End If
            If objXLWs.Range("V" & 1).Value.ToString <> itemMasterAttributes(21) Then
                valid = False
            End If
            If objXLWs.Range("W" & 1).Value.ToString <> itemMasterAttributes(22) Then
                valid = False
            End If
            If objXLWs.Range("X" & 1).Value.ToString <> itemMasterAttributes(23) Then
                valid = False
            End If
            lblOperation.Text = ""
            objXLApp.Quit()

        Catch ex As Exception
            MsgBox(ex.Message)
            valid = False
        End Try
        lblOperation.Text = ""
        Return valid
    End Function
    Private Function getRecordCount(path As String)
        Dim count As Integer = 0
        Try
            Dim objXLApp As Microsoft.Office.Interop.Excel.Application
            Dim objXLWb As Excel.Workbook
            Dim objXLWs As Excel.Worksheet
            objXLApp = New Excel.Application
            objXLApp.Workbooks.Open(path)
            objXLWb = objXLApp.Workbooks(1)
            objXLWs = objXLWb.Worksheets(1)
            count = objXLWs.UsedRange.Rows.Count
            objXLApp.Quit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return count
    End Function
    Private Function validateMasterRecords(path As String)
        Dim valid As Boolean = True
        Dim count As Integer = getRecordCount(path)
        '  MsgBox("Total number of records:  " + (count - 1).ToString)
        Dim k As Integer = 0
        Try
            Dim objXLApp As Excel.Application
            Dim objXLWb As Excel.Workbook
            Dim objXLWs As Excel.Worksheet
            objXLApp = New Excel.Application
            objXLApp.Workbooks.Open(path)
            objXLWb = objXLApp.Workbooks(1)
            objXLWs = objXLWb.Worksheets(1)

            'validate item codes, for duplicates and empty string
            lblOperation.Text = "Validating Records... please wait"
            prgBar.Value = 0
            Dim res As Integer = MsgBox("Total records " + (count - 1).ToString, vbYesNo, "Continue?")
            If res = DialogResult.No Then
                valid = False
                Return valid
                Exit Function
            End If
            ' valid = True
            For i As Integer = 2 To count
                k = i
                showProgress(i, count)
                Dim itemcode As String = objXLWs.Range("A" & i).Value.ToString

                '              Dim scancode As String = objXLWs.Range("B" & i).Value.ToString
                '           Dim descr As String = objXLWs.Range("C" & i).Value.ToString
                '           Dim short_descr As String = objXLWs.Range("D" & i).Value.ToString
                '           Dim pck As String = objXLWs.Range("E" & i).Value.ToString
                '           Dim dept_name As String = objXLWs.Range("G" & i).Value.ToString
                '           Dim _class_name As String = objXLWs.Range("I" & i).Value.ToString
                '            Dim sub_class_name As String = objXLWs.Range("K" & i).Value.ToString
                '            Dim supplier As String = objXLWs.Range("L" & i).Value.ToString
                '           Dim cprice_vat_excl As String = objXLWs.Range("N" & i).Value.ToString
                '          Dim vat As String = objXLWs.Range("O" & i).Value.ToString
                '          Dim cprice_vat_incl As String = objXLWs.Range("P" & i).Value.ToString
                '          Dim margin As String = objXLWs.Range("Q" & i).Value.ToString
                '          Dim discount As String = objXLWs.Range("R" & i).Value.ToString
                '         Dim sprice As String = objXLWs.Range("S" & i).Value.ToString
                '          Dim stock As String = objXLWs.Range("T" & i).Value.ToString
                '         Dim min_stock As String = objXLWs.Range("U" & i).Value.ToString
                '         Dim max_stock As String = objXLWs.Range("V" & i).Value.ToString
                '         Dim reorder_level As String = objXLWs.Range("W" & i).Value.ToString
                '         Dim uom As String = objXLWs.Range("X" & i).Value.ToString

                'For j As Integer = i + 1 To count
                If itemcode = "" Or itemcode = vbNull Then
                    valid = False
                    MsgBox("Empty field in item code in record no " + i.ToString)
                    'Exit For
                Else
                    'valid = True
                End If

                '           If itemcode.Contains("'") Or scancode.Contains("'") Or descr.Contains("'") Or short_descr.Contains("'") Or pck.Contains("'") Or dept_name.Contains("'") Or _class_name.Contains("'") Or sub_class_name.Contains("'") Or supplier.Contains("'") Or cprice_vat_excl.Contains("'") Or vat.Contains("'") Or cprice_vat_incl.Contains("'") Or margin.Contains("'") Or discount.Contains("'") Or sprice.Contains("'") Or stock.Contains("'") Or min_stock.Contains("'") Or max_stock.Contains("'") Or reorder_level.Contains("'") Or uom.Contains("'") Then
                '           MsgBox("Invalid character ' at record no" + i.ToString)
                '           valid = False
                'Exit For
                '            End If

                'If valid = False Then
                'Exit For
                'End If
                ' Next
                If valid = False Then
                    Exit For
                End If
            Next
            lblOperation.Text = ""
            prgBar.Value = 0
            objXLApp.Quit()
        Catch e As NullReferenceException
            valid = False
            MsgBox("Error in record no " + k.ToString + " This record might have an empty value in itemcode. Please fix the problem without proceeding")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return valid
    End Function
    Private Sub showProgress(number As Integer, count As Integer)
        prgBar.Value = (number / count) * 100
    End Sub

    Private Sub btnUploadMaster_Click(sender As Object, e As EventArgs) Handles btnUploadMaster.Click
        Cursor = Cursors.WaitCursor
        path = ""
        count = 0

        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateMasterFormat(path) = True Then
                count = getRecordCount(path)
                If validateMasterRecords(path) Then

                    Dim objXLApp As Excel.Application
                    Dim objXLWb As Excel.Workbook
                    Dim objXLWs As Excel.Worksheet

                    objXLApp = New Excel.Application
                    objXLApp.Workbooks.Open(path)
                    objXLWb = objXLApp.Workbooks(1)
                    objXLWs = objXLWb.Worksheets(1)

                    Try
                        prgBar.Value = 0
                        lblOperation.Text = "Uploading... please wait"
                        For i As Integer = 2 To count
                            showProgress(i, count)
                            'upload items

                            Dim itemcode As String = objXLWs.Range("A" & i).Value
                            Dim scancode As String = objXLWs.Range("B" & i).Value
                            Dim descr As String = objXLWs.Range("C" & i).Value
                            Dim short_descr As String = objXLWs.Range("D" & i).Value
                            Dim pck As String = objXLWs.Range("E" & i).Value
                            Dim dept_name As String = objXLWs.Range("G" & i).Value
                            Dim _class_name As String = objXLWs.Range("I" & i).Value
                            Dim sub_class_name As String = objXLWs.Range("K" & i).Value
                            Dim supplier As String = objXLWs.Range("L" & i).Value
                            Dim cprice_vat_excl As String = objXLWs.Range("N" & i).Value
                            Dim vat As String = objXLWs.Range("O" & i).Value
                            Dim cprice_vat_incl As String = objXLWs.Range("P" & i).Value
                            Dim margin As String = objXLWs.Range("Q" & i).Value
                            Dim discount As String = objXLWs.Range("R" & i).Value
                            Dim sprice As String = objXLWs.Range("S" & i).Value
                            Dim stock As String = objXLWs.Range("T" & i).Value
                            Dim min_stock As String = objXLWs.Range("U" & i).Value
                            Dim max_stock As String = objXLWs.Range("V" & i).Value
                            Dim reorder_level As String = objXLWs.Range("W" & i).Value
                            Dim uom As String = objXLWs.Range("X" & i).Value

                            Dim conn As New MySqlConnection(Database.conString)
                            conn.Open()
                            Dim command As New MySqlCommand()
                            command.Connection = conn
                            command.CommandText = "INSERT IGNORE INTO `items`(`item_code`, `item_scan_code`,`item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`) VALUES (@item_code,@item_scan_code,@item_long_description,@item_description,@pck,@department_id,@class_id,@sub_class_id,@supplier_id,@unit_cost_price,@retail_price,@discount,@vat,@margin,@standard_uom)"
                            command.Prepare()
                            command.Parameters.AddWithValue("@item_code", removeInvalidCharacters(itemcode))
                            command.Parameters.AddWithValue("@item_scan_code", removeInvalidCharacters(scancode))
                            command.Parameters.AddWithValue("@item_long_description", removeInvalidCharacters(descr))
                            command.Parameters.AddWithValue("@item_description", removeInvalidCharacters(short_descr))
                            command.Parameters.AddWithValue("@pck", removeInvalidCharacters(pck))
                            command.Parameters.AddWithValue("@department_id", (New Department).getDepartmentID(removeInvalidCharacters(dept_name)))
                            command.Parameters.AddWithValue("@class_id", (New Class_).getClassID(removeInvalidCharacters(_class_name)))
                            command.Parameters.AddWithValue("@sub_class_id", (New SubClass).getSubClassID(removeInvalidCharacters(sub_class_name)))
                            command.Parameters.AddWithValue("@supplier_id", (New Supplier).getSupplierID(removeInvalidCharacters(supplier), ""))
                            command.Parameters.AddWithValue("@unit_cost_price", removeInvalidCharacters(cprice_vat_incl))
                            command.Parameters.AddWithValue("@retail_price", removeInvalidCharacters(sprice))
                            command.Parameters.AddWithValue("@discount", removeInvalidCharacters(discount))
                            command.Parameters.AddWithValue("@vat", removeInvalidCharacters(vat))
                            command.Parameters.AddWithValue("@margin", removeInvalidCharacters(margin))
                            command.Parameters.AddWithValue("@standard_uom", removeInvalidCharacters(uom))
                            command.ExecuteNonQuery()
                            conn.Close()
                            If scancode <> "" Then
                                conn.Open()
                                command.Connection = conn
                                command.CommandText = "INSERT IGNORE INTO `bar_codes`(`item_scan_code`, `item_code`) VALUES (@item_scan_code,@item_code)"
                                command.Prepare()
                                command.Parameters.AddWithValue("@item_code", itemcode.Replace("'", ""))
                                command.Parameters.AddWithValue("@item_scan_code", scancode.Replace("'", ""))
                                command.ExecuteNonQuery()
                                conn.Close()
                            End If
                            conn.Open()
                            command.Connection = conn
                            command.CommandText = "INSERT IGNORE INTO `inventorys`(`item_code`) VALUES (@item_code)"
                            command.Prepare()
                            command.Parameters.AddWithValue("@item_code", itemcode.Replace("'", ""))
                            command.ExecuteNonQuery()
                            conn.Close()

                            '     Dim stockCard As New StockCard
                            '     StockCard.qtyIn(Day.DAY, itemcode, Val(stock), Val(stock), "Opening Balance, Mass upload")

                        Next
                        lblOperation.Text = ""
                        MsgBox("Operation completed")
                        prgBar.Value = 0
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                    objXLApp.Quit()
                Else
                    MsgBox("Operation failed. Incomplete records")
                    prgBar.Value = 0
                End If

            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnUpdatePrice_Click(sender As Object, e As EventArgs) Handles btnUpdatePrice.Click
        Cursor = Cursors.WaitCursor
        path = ""
        count = 0
        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateMasterFormat(path) = True Then
                count = getRecordCount(path)
                If validateMasterRecords(path) Then

                    Dim objXLApp As Excel.Application
                    Dim objXLWb As Excel.Workbook
                    Dim objXLWs As Excel.Worksheet

                    objXLApp = New Excel.Application
                    objXLApp.Workbooks.Open(path)
                    objXLWb = objXLApp.Workbooks(1)
                    objXLWs = objXLWb.Worksheets(1)

                    Try
                        prgBar.Value = 0
                        lblOperation.Text = "Updating prices... please wait"
                        For i As Integer = 2 To count
                            showProgress(i, count)



                            'upload items
                            Dim itemcode As String = objXLWs.Range("A" & i).Value
                            'Dim scancode As String = objXLWs.Range("B" & i).Value
                            'Dim descr As String = objXLWs.Range("C" & i).Value
                            ' Dim short_descr As String = objXLWs.Range("D" & i).Value
                            'Dim pck As String = objXLWs.Range("E" & i).Value
                            'Dim dept_name As String = objXLWs.Range("G" & i).Value
                            'Dim _class_name As String = objXLWs.Range("I" & i).Value
                            'Dim sub_class_name As String = objXLWs.Range("K" & i).Value
                            'Dim supplier As String = objXLWs.Range("L" & i).Value
                            Dim cprice_vat_excl As String = objXLWs.Range("N" & i).Value
                            Dim vat As String = objXLWs.Range("O" & i).Value
                            Dim cprice_vat_incl As String = objXLWs.Range("P" & i).Value
                            Dim margin As String = objXLWs.Range("Q" & i).Value
                            Dim discount As String = objXLWs.Range("R" & i).Value
                            Dim sprice As String = objXLWs.Range("S" & i).Value
                            'Dim stock As String = objXLWs.Range("T" & i).Value
                            'Dim min_stock As String = objXLWs.Range("U" & i).Value
                            'Dim max_stock As String = objXLWs.Range("V" & i).Value
                            'Dim reorder_level As String = objXLWs.Range("W" & i).Value
                            'Dim uom As String = objXLWs.Range("X" & i).Value
                            If itemcode = "" Then
                                Continue For
                            End If
                            Dim oldPrice As Double = (New Item).getItemPrice(itemcode)
                            If oldPrice = Val(sprice) Then
                                Continue For
                            End If
                            Dim conn As New MySqlConnection(Database.conString)
                            conn.Open()
                            Dim command As New MySqlCommand()
                            command.Connection = conn
                            command.CommandText = "UPDATE `items` SET `unit_cost_price`='" + cprice_vat_incl + "',`retail_price`='" + sprice + "',`discount`='" + discount + "',`vat`='" + vat + "',`margin`='" + margin + "' WHERE `item_code`='" + itemcode + "'"
                            command.Prepare()
                            command.ExecuteNonQuery()
                            conn.Close()
                            Dim _item As New Item
                            _item.changePrice(itemcode, oldPrice, Val(sprice), "Mass price update")
                        Next
                        lblOperation.Text = ""
                        MsgBox("Operation completed")
                        prgBar.Value = 0
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    objXLApp.Quit()
                Else
                    MsgBox("Operation failed. Incomplete records")
                    prgBar.Value = 0
                End If

            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
        Cursor = Cursors.Default
    End Sub



    Private Sub btnUpdateInventory_Click(sender As Object, e As EventArgs) Handles btnUpdateInventory.Click
        Cursor = Cursors.WaitCursor
        path = ""
        count = 0

        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateMasterFormat(path) = True Then
                count = getRecordCount(path)
                If validateMasterRecords(path) Then

                    Dim objXLApp As Excel.Application
                    Dim objXLWb As Excel.Workbook
                    Dim objXLWs As Excel.Worksheet

                    objXLApp = New Excel.Application
                    objXLApp.Workbooks.Open(path)
                    objXLWb = objXLApp.Workbooks(1)
                    objXLWs = objXLWb.Worksheets(1)

                    Try
                        prgBar.Value = 0
                        lblOperation.Text = "Updating stocks... please wait"
                        For i As Integer = 2 To count
                            showProgress(i, count)
                            'upload items
                            Dim itemcode As String = objXLWs.Range("A" & i).Value
                            Dim qty As String = objXLWs.Range("T" & i).Value

                            Dim conn As New MySqlConnection(Database.conString)
                            conn.Open()
                            Dim command As New MySqlCommand()
                            command.Connection = conn
                            command.CommandText = "UPDATE `inventorys` SET `qty`='" + qty + "' WHERE `item_code`='" + itemcode + "'"
                            command.Prepare()
                            command.ExecuteNonQuery()
                            conn.Close()
                            Dim stockCard As New StockCard
                            stockCard.qtyIn(Day.DAY, itemcode, Val(qty), Val(qty), "Stock adjustment, Mass update")
                        Next
                        lblOperation.Text = ""
                        MsgBox("Operation completed")
                        prgBar.Value = 0
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    objXLApp.Quit()
                Else
                    MsgBox("Operation failed. Incomplete records")
                    prgBar.Value = 0
                End If

            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnUpdateMaster_Click(sender As Object, e As EventArgs) Handles btnUpdateMaster.Click
        Cursor = Cursors.WaitCursor
        path = ""
        count = 0

        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateMasterFormat(path) = True Then
                count = getRecordCount(path)
                If validateMasterRecords(path) Then

                    Dim objXLApp As Excel.Application
                    Dim objXLWb As Excel.Workbook
                    Dim objXLWs As Excel.Worksheet

                    objXLApp = New Excel.Application
                    objXLApp.Workbooks.Open(path)
                    objXLWb = objXLApp.Workbooks(1)
                    objXLWs = objXLWb.Worksheets(1)

                    Try
                        prgBar.Value = 0
                        lblOperation.Text = "Updating... please wait"
                        For i As Integer = 2 To count
                            showProgress(i, count)
                            'upload items

                            Dim itemcode As String = objXLWs.Range("A" & i).Value
                            Dim scancode As String = objXLWs.Range("B" & i).Value
                            Dim descr As String = objXLWs.Range("C" & i).Value
                            Dim short_descr As String = objXLWs.Range("D" & i).Value
                            Dim pck As String = objXLWs.Range("E" & i).Value
                            Dim dept_name As String = objXLWs.Range("G" & i).Value
                            Dim _class_name As String = objXLWs.Range("I" & i).Value
                            Dim sub_class_name As String = objXLWs.Range("K" & i).Value
                            Dim supplier As String = objXLWs.Range("L" & i).Value
                            Dim cprice_vat_excl As String = objXLWs.Range("N" & i).Value
                            Dim vat As String = objXLWs.Range("O" & i).Value
                            Dim cprice_vat_incl As String = objXLWs.Range("P" & i).Value
                            Dim margin As String = objXLWs.Range("Q" & i).Value
                            Dim discount As String = objXLWs.Range("R" & i).Value
                            Dim sprice As String = objXLWs.Range("S" & i).Value
                            Dim stock As String = objXLWs.Range("T" & i).Value
                            Dim min_stock As String = objXLWs.Range("U" & i).Value
                            Dim max_stock As String = objXLWs.Range("V" & i).Value
                            Dim reorder_level As String = objXLWs.Range("W" & i).Value
                            Dim uom As String = objXLWs.Range("X" & i).Value



                            Dim conn As New MySqlConnection(Database.conString)
                            conn.Open()
                            Dim command As New MySqlCommand()
                            command.Connection = conn
                            command.CommandText = "UPDATE `items`
                                                        SET
                                                            `item_long_description`='" + removeInvalidCharacters(descr) + "',
                                                            `item_description`='" + removeInvalidCharacters(short_descr) + "',
                                                            `pck`='" + removeInvalidCharacters(pck) + "',
                                                            `department_id`='" + (New Department).getDepartmentID(removeInvalidCharacters(dept_name)) + "',
                                                            `class_id`='" + (New Class_).getClassID(removeInvalidCharacters(_class_name)) + "',
                                                            `sub_class_id`='" + (New SubClass).getSubClassID(removeInvalidCharacters(sub_class_name)) + "',
                                                            `supplier_id`='" + (New Supplier).getSupplierID(removeInvalidCharacters(supplier), "") + "',
                                                            `unit_cost_price`='" + removeInvalidCharacters(cprice_vat_incl) + "',
                                                            `retail_price`='" + removeInvalidCharacters(sprice) + "',
                                                            `discount`='" + removeInvalidCharacters(discount) + "',
                                                            `vat`='" + removeInvalidCharacters(vat) + "',
                                                            `margin`='" + removeInvalidCharacters(margin) + "',
                                                            `standard_uom`='" + removeInvalidCharacters(uom) + "' 
                                                        WHERE 
                                                            `item_code`='" + removeInvalidCharacters(itemcode) + "'"

                            command.Prepare()
                            command.ExecuteNonQuery()
                            conn.Close()

                            '  Dim stockCard As New StockCard
                            '  StockCard.qtyIn(Day.DAY, itemcode, Val(stock), Val(stock), "Stock adjustment, Mass update")

                        Next
                        lblOperation.Text = ""
                        MsgBox("Operation completed")
                        prgBar.Value = 0
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                    objXLApp.Quit()
                Else
                    MsgBox("Operation failed. Incomplete records")
                    prgBar.Value = 0
                End If

            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
        Cursor = Cursors.Default
    End Sub
    Private Function removeInvalidCharacters(value As String) As String
        Try
            value = value.Replace("'", "")
        Catch ex As Exception
            Return value
        End Try
        Return value
    End Function

    Private Sub btnGenerateItemMasterTemplate_Click(sender As Object, e As EventArgs) Handles btnGenerateItemMasterTemplate.Click
        Cursor = Cursors.WaitCursor
        Dim appXL As Excel.Application
        Dim wbXl As Excel.Workbook
        Dim shXL As Excel.Worksheet
        Dim raXL As Excel.Range
        ' Start Excel and get Application object.
        appXL = CreateObject("Excel.Application")
        appXL.Visible = True
        ' Add a new workbook.
        wbXl = appXL.Workbooks.Add
        shXL = wbXl.ActiveSheet

        Dim r As Integer = 1
        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "ITEM_CODE"
        shXL.Cells(r, 2).Value = "PRIMARY_SCAN_CODE"
        shXL.Cells(r, 3).Value = "DESCR"
        shXL.Cells(r, 4).Value = "SHORT_DESCR"
        shXL.Cells(r, 5).Value = "PACK_SIZE"
        shXL.Cells(r, 6).Value = "DEPT"
        shXL.Cells(r, 7).Value = "DEPT_NAME"
        shXL.Cells(r, 8).Value = "CLASS"
        shXL.Cells(r, 9).Value = "CLASS_NAME"
        shXL.Cells(r, 10).Value = "SUB_CLASS"
        shXL.Cells(r, 11).Value = "SUB_CLASS_NAME"
        shXL.Cells(r, 12).Value = "SUPPLIER"
        shXL.Cells(r, 13).Value = "SUPPLIER_NAME"
        shXL.Cells(r, 14).Value = "CPRICE_VAT_EXCL"
        shXL.Cells(r, 15).Value = "VAT"
        shXL.Cells(r, 16).Value = "CPRICE_VAT_INCL"
        shXL.Cells(r, 17).Value = "MARGIN"
        shXL.Cells(r, 18).Value = "DISC"
        shXL.Cells(r, 19).Value = "SPRICE"
        shXL.Cells(r, 20).Value = "STOCK"
        shXL.Cells(r, 21).Value = "MIN_STOCK"
        shXL.Cells(r, 22).Value = "MAX_STOCK"
        shXL.Cells(r, 23).Value = "REORDER_LEVEL"
        shXL.Cells(r, 24).Value = "UOM"
        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A1", "X1")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With


        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "X1")
        raXL.EntireColumn.AutoFit()
        Dim strFileName As String = LSystem.saveToDesktop & "\Product Master Template.xls"
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(strFileName) Then
            Try
                'System.IO.File.Delete(strFileName)
            Catch ex As Exception
            End Try
        End If
        Try
            wbXl.Save()
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

    End Sub

    Private Sub btnDownloadMaster_Click(sender As Object, e As EventArgs) Handles btnDownloadMaster.Click
        Cursor = Cursors.WaitCursor
        Dim appXL As Excel.Application
        Dim wbXl As Excel.Workbook
        Dim shXL As Excel.Worksheet
        Dim raXL As Excel.Range
        ' Start Excel and get Application object.
        appXL = CreateObject("Excel.Application")
        appXL.Visible = True
        ' Add a new workbook.
        wbXl = appXL.Workbooks.Add
        shXL = wbXl.ActiveSheet

        Dim r As Integer = 1

        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "ITEM_CODE"
        shXL.Cells(r, 2).Value = "PRIMARY_SCAN_CODE"
        shXL.Cells(r, 3).Value = "DESCR"
        shXL.Cells(r, 4).Value = "SHORT_DESCR"
        shXL.Cells(r, 5).Value = "PACK_SIZE"
        shXL.Cells(r, 6).Value = "DEPT"
        shXL.Cells(r, 7).Value = "DEPT_NAME"
        shXL.Cells(r, 8).Value = "CLASS"
        shXL.Cells(r, 9).Value = "CLASS_NAME"
        shXL.Cells(r, 10).Value = "SUB_CLASS"
        shXL.Cells(r, 11).Value = "SUB_CLASS_NAME"
        shXL.Cells(r, 12).Value = "SUPPLIER"
        shXL.Cells(r, 13).Value = "SUPPLIER_NAME"
        shXL.Cells(r, 14).Value = "CPRICE_VAT_EXCL"
        shXL.Cells(r, 15).Value = "VAT"
        shXL.Cells(r, 16).Value = "CPRICE_VAT_INCL"
        shXL.Cells(r, 17).Value = "MARGIN"
        shXL.Cells(r, 18).Value = "DISC"
        shXL.Cells(r, 19).Value = "SPRICE"
        shXL.Cells(r, 20).Value = "STOCK"
        shXL.Cells(r, 21).Value = "MIN_STOCK"
        shXL.Cells(r, 22).Value = "MAX_STOCK"
        shXL.Cells(r, 23).Value = "REORDER_LEVEL"
        shXL.Cells(r, 24).Value = "UOM"
        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A1", "X1")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim suppcommand As New MySqlCommand()
            Dim query As String = "SELECT  `item_code`, `item_scan_code`, `item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`,`active` FROM `items`"
            conn.Open()
            suppcommand.CommandText = query
            suppcommand.Connection = conn
            suppcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = suppcommand.ExecuteReader

            If reader.HasRows Then
                Dim supplier As New Supplier
                Dim department As New Department
                Dim class_ As New Class_
                Dim subclass As New SubClass
                While reader.Read
                    lblOperation.Text = "Downloading... please wait"
                    If reader.GetString("item_code") <> "" Then
                        r = r + 1
                        shXL.Cells(r, 1).Value = reader.GetString("item_code")
                        shXL.Cells(r, 2).Value = reader.GetString("item_scan_code")
                        shXL.Cells(r, 3).Value = reader.GetString("item_long_description")
                        shXL.Cells(r, 4).Value = reader.GetString("item_description")
                        shXL.Cells(r, 5).Value = reader.GetString("pck")
                        shXL.Cells(r, 6).Value = ""
                        shXL.Cells(r, 7).Value = department.getDepartmentName(reader.GetString("department_id"))
                        shXL.Cells(r, 8).Value = ""
                        shXL.Cells(r, 9).Value = class_.getClassName(reader.GetString("class_id"))
                        shXL.Cells(r, 10).Value = ""
                        shXL.Cells(r, 11).Value = subclass.getSubClassName(reader.GetString("sub_class_id"))
                        shXL.Cells(r, 12).Value = supplier.getSupplierCode(reader.GetString("supplier_id"), "")
                        shXL.Cells(r, 13).Value = supplier.getSupplierName(reader.GetString("supplier_id"), "")
                        shXL.Cells(r, 14).Value = ""
                        shXL.Cells(r, 15).Value = reader.GetString("vat")
                        shXL.Cells(r, 16).Value = reader.GetString("unit_cost_price")
                        shXL.Cells(r, 17).Value = reader.GetString("margin")
                        shXL.Cells(r, 18).Value = reader.GetString("discount")
                        shXL.Cells(r, 19).Value = reader.GetString("retail_price")
                        shXL.Cells(r, 20).Value = (New Inventory).getInventory(reader.GetString("item_code"))
                        shXL.Cells(r, 21).Value = (New Inventory).getMinInventory(reader.GetString("item_code"))
                        shXL.Cells(r, 22).Value = (New Inventory).getMaxInventory(reader.GetString("item_code"))
                        shXL.Cells(r, 23).Value = (New Inventory).getReorderLevel(reader.GetString("item_code"))
                        shXL.Cells(r, 24).Value = reader.GetString("standard_uom")
                    End If
                End While
                lblOperation.Text = ""
            End If
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            MsgBox(ex.Message)
        End Try
        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "X1")
        raXL.EntireColumn.AutoFit()



        Dim strFileName As String = LSystem.saveToDesktop & "\Product Master.xls"
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(strFileName) Then
            Try
                'System.IO.File.Delete(strFileName)
            Catch ex As Exception
            End Try
        End If
        Try
            wbXl.Save()
        Catch ex As Exception

        End Try




        ' Make sure Excel is visible and give the user control
        ' of Excel's lifetime.
        '      appXL.Visible = True
        '      appXL.UserControl = True
        ' Release object references.
        '      raXL = Nothing
        '      shXL = Nothing
        '       wbXl = Nothing
        '      appXL.Quit()
        '      appXL = Nothing
        Cursor = Cursors.Default
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

    End Sub
End Class