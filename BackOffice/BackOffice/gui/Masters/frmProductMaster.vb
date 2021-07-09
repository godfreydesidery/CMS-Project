Option Explicit On

'Imports Microsoft.Office.Interop
Imports Devart.Data.MySql

Public Class frmProductMaster
    Dim RECORD_MODE As Integer = 0 ' 0 save new, 1 save existing
    Dim NEW_SPECIAL As Integer = 0

    Dim supplierID As String = ""
    Dim departmentID As String = ""
    Dim classID As String = ""
    Dim subClassID As String = ""

    Dim barCode As String = ""
    Dim itemCode As String = ""
    Dim description As String = ""
    Dim longDescription As String = ""
    Dim pck As String = ""

    Dim costPrice As Double = 0
    Dim retailPrice As Double = 0
    Dim vat As Double = 0

    Dim discount As Double = 0
    Dim supplier As String = 0
    Dim _margin As Double = 0
    Dim standardUOM As String = ""
    Dim department As String = ""
    Dim _class As String = ""
    Dim subClass As String = ""
    Dim active As String = ""
    Dim sellable As String = ""
    Private Function assignValues()
        barCode = txtBarCode.Text
        itemCode = txtItemCode.Text
        longDescription = cmbDescription.Text
        description = txtDescription.Text
        pck = cmbPck.Text
        costPrice = Val(txtCostPrice.Text)
        retailPrice = Val(txtRetailPrice.Text)
        vat = Val(txtVAT.Text)
        discount = Val(txtDiscount.Text)
        supplier = cmbSupplier.Text
        _margin = Val(txtMargin.Text)
        standardUOM = txtStandardUOM.Text
        department = cmbDepartment.Text
        _class = cmbClass.Text
        subClass = cmbSubClass.Text
        Return vbNull
    End Function
    Private Function validateInput()
        Dim valid As Boolean = False
        'code
        valid = True

        Return valid
    End Function
    Private Function getValues()
        txtBarCode.Text = barCode
        txtItemCode.Text = itemCode
        txtDescription.Text = description
        cmbDescription.Text = longDescription
        cmbPck.Text = pck
        txtCostPrice.Text = costPrice
        txtRetailPrice.Text = retailPrice
        txtVAT.Text = vat
        txtDiscount.Text = discount
        'cmbSupplier.Text = supplier
        txtMargin.Text = _margin
        txtStandardUOM.Text = standardUOM
        'cmbDepartment.Text = department
        'cmbClass.Text = _class
        'cmbSubClass.Text = subClass
        Return vbNull
    End Function

    Private Function saveExisting()
        Dim saved As Boolean = False
        Dim oldPrice As Double = (New Item).getItemPrice(itemCode)
        Try
            assignValues()
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim Query As String = "UPDATE `items` SET `item_long_description`=@item_long_description,`item_description`=@item_description,`pck`=@pck,`department_id`=@department_id,`class_id`=@class_id,`sub_class_id`=@sub_class_id,`supplier_id`=@supplier_id,`unit_cost_price`=@unit_cost_price,`retail_price`=@retail_price,`discount`=@discount,`vat`=@vat,`margin`=@margin,`standard_uom`=@standard_uom,`active`=@active,`sellable`=@sellable WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@item_long_description", longDescription)
            command.Parameters.AddWithValue("@item_description", description)
            command.Parameters.AddWithValue("@pck", pck)
            command.Parameters.AddWithValue("@department_id", departmentID)
            command.Parameters.AddWithValue("@class_id", classID)
            command.Parameters.AddWithValue("@sub_class_id", subClassID)
            command.Parameters.AddWithValue("@supplier_id", (New Supplier).getSupplierID("", supplier))
            command.Parameters.AddWithValue("@unit_cost_price", costPrice)
            command.Parameters.AddWithValue("@retail_price", retailPrice)
            command.Parameters.AddWithValue("@discount", discount)
            command.Parameters.AddWithValue("@vat", vat)
            command.Parameters.AddWithValue("@margin", _margin)
            command.Parameters.AddWithValue("@standard_uom", standardUOM)
            If chkDiscontinued.Checked = False Then
                active = "1"
            Else
                active = "0"
            End If
            command.Parameters.AddWithValue("@active", active)
            If chkSellable.Checked = True Then
                sellable = "1"
            Else
                sellable = "0"
            End If
            command.Parameters.AddWithValue("@sellable", sellable)
            command.ExecuteNonQuery()
            conn.Close()
            saved = True

            Dim _item As New Item
            _item.changePrice(itemCode, oldPrice, retailPrice, "Single edit by user")

        Catch ex As Exception
            MsgBox("Item information could not be updated.", vbCritical + vbOKOnly, "Error: Update failed")
        End Try
        Return saved
        Return vbNull
    End Function
    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub
    Private Sub lock()
        txtBarCode.ReadOnly = True
        txtItemCode.ReadOnly = True
        cmbDescription.Enabled = False
        txtDescription.ReadOnly = True
        txtCostPrice.ReadOnly = True
        txtRetailPrice.ReadOnly = True
        txtVAT.ReadOnly = True
        txtDiscount.ReadOnly = True
        txtMargin.ReadOnly = True
        txtStandardUOM.ReadOnly = True
        cmbSupplier.Enabled = False
    End Sub
    Private Sub unlock()
        txtBarCode.ReadOnly = False
        txtItemCode.ReadOnly = False
        cmbDescription.Enabled = True
        txtDescription.ReadOnly = False
        txtCostPrice.ReadOnly = False
        txtRetailPrice.ReadOnly = False
        txtVAT.ReadOnly = False
        txtDiscount.ReadOnly = False
        txtMargin.ReadOnly = False
        txtStandardUOM.ReadOnly = False
        'cmbSupplier.Enabled = True
    End Sub
    Private Function clearAll()
        txtBarCode.Text = ""
        txtItemCode.Text = ""
        cmbDescription.Text = ""
        txtDescription.Text = ""
        cmbPck.Text = ""
        txtCostPrice.Text = ""
        txtRetailPrice.Text = ""
        txtVAT.Text = ""
        txtDiscount.Text = ""
        cmbSupplier.Text = ""
        txtMargin.Text = ""
        txtStandardUOM.Text = ""
        cmbDepartment.Text = ""
        cmbClass.Text = ""
        cmbSubClass.Text = ""

        supplierID = ""
        departmentID = ""
        classID = ""
        subClassID = ""

        barCode = ""
        itemCode = ""
        description = ""
        pck = ""

        costPrice = 0
        retailPrice = 0
        vat = 0

        discount = 0
        supplier = 0
        _margin = 0
        standardUOM = 0
        department = ""
        _class = ""
        subClass = ""

        chkDiscontinued.Checked = False
        chkSellable.Checked = False

        Return vbNull
    End Function
    Private Function getMargin(costPrice As Double, sellingPrice As Double) As Double
        Dim margin_ As Double = 0
        margin_ = ((sellingPrice - costPrice) / costPrice) * 100
        Return margin_
    End Function
    Private Function getSellingPrice(costPrice As Double, margin_ As Double) As Double
        Dim sellingPrice As Double = 0
        sellingPrice = (Math.Ceiling((costPrice * ((margin_ / 100) + 1)) / 100)) * 100
        Return sellingPrice
    End Function
    Private Function validateData()
        Dim valid As Boolean = True

        Return valid
    End Function
    Private Function search(itemCode As String) As Boolean
        Dim found As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim suppcommand As New MySqlCommand()
            Dim query As String = "SELECT  `item_code`, `item_scan_code`, `item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`,`active`, `sellable` FROM `items` WHERE `item_code`='" + itemCode + "'"
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
                    txtItemCode.Text = reader.GetString("item_code")
                    cmbDescription.Text = reader.GetString("item_long_description")
                    txtDescription.Text = reader.GetString("item_description")
                    cmbPck.Text = reader.GetString("pck")
                    cmbDepartment.Text = department.getDepartmentName(reader.GetString("department_id"))
                    cmbClass.Text = class_.getClassName(reader.GetString("class_id"))
                    cmbSubClass.Text = subclass.getSubClassName(reader.GetString("sub_class_id"))
                    cmbSupplier.Text = supplier.getSupplierName(reader.GetString("supplier_id"), "")
                    txtCostPrice.Text = reader.GetString("unit_cost_price")
                    txtRetailPrice.Text = reader.GetString("retail_price")
                    txtDiscount.Text = reader.GetString("discount")
                    txtVAT.Text = reader.GetString("vat")
                    txtMargin.Text = reader.GetString("margin")
                    txtStandardUOM.Text = reader.GetString("standard_uom")
                    If reader.GetString("active") = "1" Then
                        chkDiscontinued.Checked = False
                    ElseIf reader.GetString("active") = "0" Then
                        chkDiscontinued.Checked = True
                    End If
                    If reader.GetString("sellable") = "1" Then
                        chkSellable.Checked = True
                    ElseIf reader.GetString("sellable") = "0" Then
                        chkSellable.Checked = False
                    End If
                    found = True
                    Exit While
                End While
            End If
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            MsgBox(ex.Message)
            Return found
            Exit Function
        End Try
        Return found
    End Function
    Private Function searchByBarCode(barCode As String) As Boolean
        Dim found As Boolean = False
        Dim item As New Item
        Dim itemcode As String = item.getItemCode(barCode, "")
        If search(itemcode) = True Then
            found = True
        End If
        Return found
    End Function
    Private Function searchByItemCode(itemCode As String) As Boolean
        Dim found As Boolean = False
        If search(itemCode) = True Then
            found = True
        End If
        Return found
    End Function
    Private Function searchByDescription(descr As String) As Boolean
        Dim found As Boolean = False
        Dim item As New Item
        Dim itemcode As String = item.getItemCode("", descr)
        If search(itemcode) = True Then
            found = True
        End If
        Return found
    End Function
    Private Function searchNew(barcode As String) As Boolean
        Dim found As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim suppcommand As New MySqlCommand()
            Dim query As String = "SELECT `item_scan_code`, `item_code`, `descr` FROM `bar_codes` WHERE `item_scan_code`='" + barcode + "'"
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
                    txtBarCode.Text = reader.GetString("item_scan_code")
                    txtItemCode.Text = reader.GetString("item_code")
                    cmbDescription.Text = reader.GetString("descr")

                    found = True
                    Exit While
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return found
            Exit Function
        End Try
        Return found
    End Function
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        NEW_SPECIAL = 0
        unlock()
        clearAll()
        btnSearch.Enabled = False
        btnSave.Enabled = True
        txtItemCode.ReadOnly = False
        RECORD_MODE = 0
        btnAddBarcode.Enabled = False
        btnDelete.Enabled = False
        generateItemCode()
    End Sub

    Private Sub btnEditInventory_Click(sender As Object, e As EventArgs) Handles btnEditInventory.Click
        If itemCode <> "" Then
            Item.GLOBAL_ITEM_CODE = itemCode
            frmEditInventory.ShowDialog()
        End If
    End Sub
    Private Sub generateItemCode()
        Dim no As String = ""

        Dim KeyGen As RandomKeyGenerator
        Dim NumKeys As Integer
        Dim i_Keys As Integer
        Dim RandomKey As String = ""

        ' MODIFY THIS TO GET MORE KEYS    - LAITH - 27/07/2005 22:48:30 -
        NumKeys = 6

        KeyGen = New RandomKeyGenerator
        KeyGen.KeyLetters = "1234567890"
        KeyGen.KeyNumbers = "0123456789"
        KeyGen.KeyChars = 3
        For i_Keys = 1 To NumKeys
            RandomKey = KeyGen.Generate()
        Next
        Dim str As String = ""
        While str.Length <> 3
            str = Math.Ceiling(VBMath.Rnd * 1000)
            If str.Length = 3 Then
                Exit While
            End If
        End While
        Dim code As String = str + RandomKey.ToString
        If (New Item).searchItem(code) Then
            generateItemCode()
        Else
            txtItemCode.Text = code
        End If

    End Sub

    Private Sub frmProductMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lock()

        If User.authorize("EDIT INVENTORY") Then
            btnEditInventory.Enabled = True
        End If

        Dim conn As New MySqlConnection(Database.conString)
        Try
            Dim suppcommand As New MySqlCommand()
            Dim supplierQuery As String = "SELECT `supplier_id`, `supplier_name` FROM `supplier`"
            conn.Open()
            suppcommand.CommandText = supplierQuery
            suppcommand.Connection = conn
            suppcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = suppcommand.ExecuteReader
            cmbSupplier.Items.Clear()
            cmbSupplier.Items.Add("")
            If reader.HasRows Then
                While reader.Read
                    cmbSupplier.Items.Add(reader.GetString("supplier_name"))
                End While
            End If
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try
        Try
            Dim deptcommand As New MySqlCommand()
            Dim departmentQuery As String = "SELECT  `department_id`, `department_name` FROM `department`"
            conn.Open()
            deptcommand.CommandText = departmentQuery
            deptcommand.Connection = conn
            deptcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = deptcommand.ExecuteReader
            cmbDepartment.Items.Clear()
            cmbDepartment.Items.Add("")
            While reader.Read
                cmbDepartment.Items.Add(reader.GetString("department_name"))
            End While
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try

        Dim item As New Item
        longList = item.getItems()
    End Sub

    Private Sub cmbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartment.SelectedIndexChanged

        Dim conn As New MySqlConnection(Database.conString)
        If cmbDepartment.Text = "" Then
            departmentID = ""
        End If
        Try
            Dim command As New MySqlCommand()
            Dim Query As String = "SELECT `department_id`, `department_name` FROM `department` WHERE `department_name`='" + cmbDepartment.Text + "'"
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader
            If reader.HasRows Then
                While reader.Read
                    departmentID = reader.GetString("department_id")
                    Exit While
                End While
            End If

            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try
        classID = ""
        cmbClass.Text = ""
        cmbClass.Items.Clear()
        subClassID = ""
        cmbSubClass.Text = ""
        cmbSubClass.Items.Clear()
        Try
            Dim command As New MySqlCommand()
            Dim Query As String = "SELECT  `class_id`, `class_name`, `department_id` FROM `class` WHERE department_id =( SELECT `department_id` FROM `department` WHERE `department_name` = '" + cmbDepartment.Text + "' )"
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader
            cmbClass.Items.Add("")
            If reader.HasRows Then
                While reader.Read
                    cmbClass.Items.Add(reader.GetString("class_name"))
                End While
            End If

            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try
    End Sub

    Private Sub cmbClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClass.SelectedIndexChanged
        Dim conn As New MySqlConnection(Database.conString)

        If cmbClass.Text = "" Then
            classID = ""
        End If
        Try
            Dim command As New MySqlCommand()
            Dim Query As String = "SELECT `class_id`, `class_name` FROM `class` WHERE `class_name`='" + cmbClass.Text + "'"
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader
            If reader.HasRows Then
                While reader.Read
                    classID = reader.GetString("class_id")
                    Exit While
                End While
            End If
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try

        cmbSubClass.Text = ""
        cmbSubClass.Items.Clear()

        Try
            Dim command As New MySqlCommand()
            Dim subclassQuery As String = "SELECT `sub_class_id`, `sub_class_name`, `class_id` FROM `sub_class` WHERE class_id =( SELECT `class_id` FROM `class` WHERE `class_name` = '" + cmbClass.Text + "' )"
            conn.Open()
            command.CommandText = subclassQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader
            cmbSubClass.Items.Add("")
            If reader.HasRows Then
                While reader.Read
                    cmbSubClass.Items.Add(reader.GetString("sub_class_name"))
                End While
            End If
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try
    End Sub

    Private Sub cmbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSupplier.SelectedIndexChanged
        Dim conn As New MySqlConnection(Database.conString)
        If cmbSupplier.Text = "" Then
            supplierID = ""
        End If
        Try
            Dim suppcommand As New MySqlCommand()
            Dim supplierQuery As String = "SELECT  `supplier_id`, `supplier_name` FROM `supplier` WHERE `supplier_name`='" + cmbSupplier.Text + "'"
            conn.Open()
            suppcommand.CommandText = supplierQuery
            suppcommand.Connection = conn
            suppcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = suppcommand.ExecuteReader
            If reader.HasRows Then
                While reader.Read
                    supplierID = reader.GetString("supplier_id")
                    Exit While
                End While
            End If

            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try
    End Sub

    Private Sub cmbSubClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubClass.SelectedIndexChanged
        If cmbSubClass.Text = "" Then
            subClassID = ""
        End If
        Dim conn As New MySqlConnection(Database.conString)

        Try
            Dim command As New MySqlCommand()
            Dim Query As String = "SELECT `sub_class_id`, `sub_class_name` FROM `sub_class` WHERE `sub_class_name`='" + cmbSubClass.Text + "'"
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader
            If reader.HasRows Then
                While reader.Read
                    subClassID = reader.GetString("sub_class_id")
                    Exit While
                End While
            End If
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try
    End Sub
    Private Function validateValues() As Boolean
        Dim valid As Boolean = True
        Dim msg As String = ""
        If txtItemCode.Text = "" Then
            msg = "Item code required"
            valid = False
            txtItemCode.Focus()
        ElseIf cmbDescription.Text = "" Then
            msg = "Long Description required"
            valid = False
            cmbDescription.Focus()
        ElseIf txtDescription.Text = "" Then
            msg = "Short Description required"
            valid = False
            txtDescription.Focus()
        ElseIf txtVAT.Text = "" Then
            msg = "VAT required"
            valid = False
            txtVAT.Focus()
        ElseIf txtCostPrice.Text = "" Or Not IsNumeric(txtCostPrice.Text) Or Val(txtCostPrice.Text) < 0 Then
            msg = "Invalid Cost price. Cost price should be numeric"
            valid = False
            txtVAT.Focus()
        ElseIf txtRetailPrice.Text = "" Or Not IsNumeric(txtRetailPrice.Text) Or Val(txtRetailPrice.Text) < 0 Then
            msg = "Invalid Retail price. Retail price should be numeric"
            valid = False
            txtVAT.Focus()
        End If
        If valid = False Then
            MsgBox("Could not complete operation. " + msg, vbOKOnly + vbCritical, "Error: Invalid entry")
            Return valid
            Exit Function
        End If
        Return valid
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validateValues() = False Then
            'stop operation if the values are invalid
            Exit Sub
        End If
        If RECORD_MODE = 0 Then
            Dim item As New Item
            If item.addNewItem(NEW_SPECIAL, txtBarCode.Text, txtItemCode.Text, cmbDescription.Text, txtDescription.Text, cmbPck.Text, txtCostPrice.Text, txtRetailPrice.Text, txtVAT.Text, txtDiscount.Text, cmbSupplier.Text, txtMargin.Text, txtStandardUOM.Text, cmbDepartment.Text, cmbClass.Text, cmbSubClass.Text) = True Then
                Dim stockCard As New StockCard
                stockCard.qtyIn(Day.DAY, txtItemCode.Text, 0, 0, "Opening balance")
                Dim res As Integer = MsgBox("The item has been successifully saved. Would you like to edit item inventory?", vbQuestion + vbYesNo, "Success: Item saved.")
                If res = DialogResult.Yes Then
                    btnSave.Enabled = False
                    frmEditInventory.ShowDialog()
                Else
                    clearAll()
                End If
            End If
        ElseIf RECORD_MODE = 1 Then
            If saveExisting() = True Then
                Dim res As Integer = MsgBox("The item information have been edited successifully. Would you like to edit item inventory??", vbQuestion + vbYesNo, "Success: Item modified.")
                If res = DialogResult.Yes Then
                    btnSave.Enabled = False
                    Item.GLOBAL_ITEM_CODE = itemCode
                    frmEditInventory.ShowDialog()
                Else
                    clearAll()
                End If
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        NEW_SPECIAL = 0
        unlock()
        RECORD_MODE = 1
        btnSave.Enabled = False
        btnSearch.Enabled = True
        txtItemCode.ReadOnly = False
        clearAll()
    End Sub
    Private Function search()
        If txtBarCode.Text = "" And txtItemCode.Text = "" And cmbDescription.Text = "" Then
            MsgBox("Please specify a record to search. Enter barcode, itemcode or long description.", vbOKOnly + vbExclamation, "Error: Search key not specified")
            Return vbNull
            Exit Function
        End If
        txtItemCode.ReadOnly = True
        txtBarCode.ReadOnly = True
        If txtBarCode.Text <> "" Then
            If searchByBarCode(txtBarCode.Text) = True Then
                itemCode = txtItemCode.Text
                Dim barcodes As List(Of String) = (New Item).getBarCodes(itemCode)
                lstBarCodes.Items.Clear()
                For i As Integer = 0 To barcodes.Count - 1
                    lstBarCodes.Items.Add(barcodes.ElementAt(i))
                Next
            End If
        ElseIf txtItemCode.Text <> "" Then
            If searchByItemCode(txtItemCode.Text) = True Then
                itemCode = txtItemCode.Text
                Dim barcodes As List(Of String) = (New Item).getBarCodes(itemCode)
                lstBarCodes.Items.Clear()
                For i As Integer = 0 To barcodes.Count - 1
                    lstBarCodes.Items.Add(barcodes.ElementAt(i))
                Next
            End If
        ElseIf cmbDescription.Text <> "" Then
            If searchByDescription(cmbDescription.Text) = True Then
                itemCode = txtItemCode.Text
                Dim barcodes As List(Of String) = (New Item).getBarCodes(itemCode)
                lstBarCodes.Items.Clear()
                For i As Integer = 0 To barcodes.Count - 1
                    lstBarCodes.Items.Add(barcodes.ElementAt(i))
                Next
            End If
        End If
        If itemCode = "" Then
            btnAddBarcode.Enabled = False
            btnDelete.Enabled = False
            MsgBox("The requested item could not be found", vbOKOnly + vbCritical, "Error: Not found")
            txtItemCode.ReadOnly = False
            txtBarCode.ReadOnly = False
        Else
            btnAddBarcode.Enabled = True
            btnDelete.Enabled = True
            btnSave.Enabled = True
        End If
        Return vbNull
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub
    Public Shared GLOBAL_ITEM_CODE As String = ""
    Private Sub btnAddBarcode_Click(sender As Object, e As EventArgs) Handles btnAddBarcode.Click
        GLOBAL_ITEM_CODE = txtItemCode.Text
        frmAddBarCode.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub txtLongDescription_TextChanged(sender As Object, e As EventArgs)
        Dim list As New List(Of String)
        Dim mySource As New AutoCompleteStringCollection
        Dim item As New Item
        list = item.getItems(cmbDescription.Text)
        mySource.AddRange(list.ToArray)
        cmbDescription.AutoCompleteCustomSource = mySource
        cmbDescription.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbDescription.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub
    Private Sub txtmargin_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMargin.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRetailPrice.Text = getSellingPrice(Val(txtCostPrice.Text), Val(txtMargin.Text)).ToString
        End If
    End Sub
    Private Sub txtretailprice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRetailPrice.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMargin.Text = getMargin(Val(txtCostPrice.Text), Val(txtRetailPrice.Text)).ToString
        End If
    End Sub
    Private Function delete(itemCode As String) As Boolean
        Dim success As Boolean = False
        If itemCode = "" Then
            MsgBox("No item selected. Please specify an item to delete.", vbOKOnly + vbCritical, "Error: No selection")
            Return vbNull
            Exit Function
        End If
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected item? All information about this item will be removed from the system.", vbYesNo + vbQuestion, "Delete item?")
        If res = DialogResult.Yes Then
            'delete the item
            'will proceed to delete the item
        Else
            'do not delete the item; discard operation
            Return vbNull
            Exit Function
        End If
        MsgBox("Could not delete")
        Return False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'delete item from item list and its inventory information
            Dim codeQuery As String = "DELETE FROM `items` WHERE `item_code`='" + itemCode + "';DELETE FROM `bar_codes` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        clearAll()
        btnSearch.Enabled = False
        Return success
    End Function
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        delete(txtItemCode.Text)
    End Sub

    Private Sub txtBarCode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtBarCode.PreviewKeyDown
        If RECORD_MODE = 0 Then
            Exit Sub
        End If
        If e.KeyCode = Keys.Tab Then
            txtItemCode.Text = ""
            cmbDescription.Text = ""
            search()
        End If
    End Sub
    Private Sub txtCode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtItemCode.PreviewKeyDown
        If RECORD_MODE = 0 Then
            Exit Sub
        End If
        If e.KeyCode = Keys.Tab Then
            txtBarCode.Text = ""
            cmbDescription.Text = ""
            search()
        End If
    End Sub
    Private Sub txtLongDescr_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If RECORD_MODE = 0 Then
            Exit Sub
        End If
        If e.KeyCode = Keys.Tab Then
            txtBarCode.Text = ""
            txtItemCode.Text = ""
            search()
        End If
    End Sub

    Private Sub txtMargin_TextChanged(sender As Object, e As EventArgs) Handles txtMargin.TextChanged

    End Sub

    Private Sub txtItemCode_TextChanged(sender As Object, e As EventArgs) Handles txtItemCode.TextChanged
        If txtItemCode.Text.Contains("'") Then
            txtItemCode.Text = ""
        End If
    End Sub

    Private Sub txtLongDescription_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtBarCode_TextChanged(sender As Object, e As EventArgs) Handles txtBarCode.TextChanged
        If txtBarCode.Text.Contains("'") Then
            txtBarCode.Text = ""
        End If
    End Sub
    Private Sub txtBarCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If RECORD_MODE <> 0 Then
                If searchByBarCode(txtBarCode.Text) = False Then
                    MsgBox("No matching item")
                End If
                Exit Sub
            End If
            If searchNew(txtBarCode.Text) = True Then
                    If (New Item).isExist(txtItemCode.Text) = False Then
                        NEW_SPECIAL = 1
                    Else
                        MsgBox("You can not add an item with this barcode. An item with similar barcode already exist", vbOKOnly + vbCritical, "Error: Duplicate enty")
                        txtBarCode.Text = ""
                        txtItemCode.Text = ""
                    cmbDescription.Text = ""
                End If
                End If
            End If
    End Sub

    'Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

    '    Dim file As String = "D:\dat4.xlsx"

    '    Dim objXLApp As Excel.Application
    '    Dim intLoopCounter As Integer
    '    Dim objXLWb As Excel.Workbook
    '    Dim objXLWs As Excel.Worksheet
    '    ' Dim objRange As Excel.Range

    '    Dim count As Integer = 0


    '    objXLApp = New Excel.Application
    '    objXLApp.Workbooks.Open(file)
    '    objXLWb = objXLApp.Workbooks(1)
    '    objXLWs = objXLWb.Worksheets(1)
    '    For intLoopCounter = 2 To 36672
    '        Dim itemcode As String = objXLWs.Range("C" & intLoopCounter).Value

    '        Dim scancode As String = objXLWs.Range("B" & intLoopCounter).Value
    '        Dim descr As String = objXLWs.Range("D" & intLoopCounter).Value
    '        'Dim deptid As String = objXLWs.Range("D" & intLoopCounter).Value
    '        'Dim deptname As String = objXLWs.Range("E" & intLoopCounter).Value
    '        'Dim classid As String = objXLWs.Range("F" & intLoopCounter).Value
    '        'Dim classname As String = objXLWs.Range("G" & intLoopCounter).Value
    '        'Dim subclassid As String = objXLWs.Range("H" & intLoopCounter).Value
    '        'Dim subclassname As String = objXLWs.Range("I" & intLoopCounter).Value
    '        'Dim unitcost As String = objXLWs.Range("K" & intLoopCounter).Value
    '        'Dim rrprice As String = objXLWs.Range("L" & intLoopCounter).Value
    '        'Dim margin As String = objXLWs.Range("N" & intLoopCounter).Value
    '        'Dim stanuom As String = objXLWs.Range("O" & intLoopCounter).Value

    '        Dim conn As New MySqlConnection("server=127.0.0.1;user id=root;password=;Database=rmsdb")
    '        conn.Open()
    '        Dim command As New MySqlCommand()
    '        command.Connection = conn
    '        command.CommandText = "INSERT IGNORE INTO `bar_cod`(`item_scan_code`, `item_code`, `descr`) VALUES (@item_scan_code,@item_code,@descr)"
    '        command.Prepare()
    '        command.Parameters.AddWithValue("@item_scan_code", scancode)
    '        command.Parameters.AddWithValue("@item_code", itemcode)
    '        command.Parameters.AddWithValue("@descr", descr)


    '        command.ExecuteNonQuery()
    '        conn.Close()
    '        txtSpan.Text = count.ToString
    '        count = count + 1
    '    Next intLoopCounter
    '    objXLApp.Quit()
    '    MsgBox("complete")
    'End Sub

    Private Sub txtSpan_TextChanged(sender As Object, e As EventArgs) Handles txtSpan.TextChanged

    End Sub

    Private Sub btnViewSuppliers_Click(sender As Object, e As EventArgs) Handles btnViewSuppliers.Click
        If itemCode <> "" Then
            GLOBAL_ITEM_CODE = txtItemCode.Text
            frmViewSuppliers.ShowDialog()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnEditSupplier.Click
        cmbSupplier.Enabled = True
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

    Private Sub cmbDescription_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDescription.SelectedIndexChanged
        If cmbDescription.Text.Contains("'") Then
            cmbDescription.Text = ""
        End If
    End Sub
    Private Sub cmbDescription_TextChanged(sender As Object, e As EventArgs) Handles cmbDescription.TextChanged

        If cmbDescription.Text.Contains("'") Then
            Try
                cmbDescription.Text = cmbDescription.Text.Replace("'", "")
            Catch ex As Exception
                cmbDescription.Text = ""
            End Try
        End If
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged
        If txtDescription.Text.Contains("'") Then
            txtDescription.Text = ""
        End If
    End Sub

    Private Sub cmbPck_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPck.SelectedIndexChanged
        If cmbPck.Text.Contains("'") Then
            cmbPck.Text = ""
        End If
    End Sub

    Private Sub txtStandardUOM_TextChanged(sender As Object, e As EventArgs) Handles txtStandardUOM.TextChanged
        If txtStandardUOM.Text.Contains("'") Then
            txtStandardUOM.Text = ""
        End If
    End Sub

    Private Sub btnViewSuppliers1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

    End Sub
End Class