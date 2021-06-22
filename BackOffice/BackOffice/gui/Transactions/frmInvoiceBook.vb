﻿Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmInvoiceBook
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles txtAmountPayed.TextChanged

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles txtAmountDue.TextChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles txtStatus.TextChanged

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles txtAmountToPay.TextChanged
        If Val(txtAmountToPay.Text) <= 0 Then
            txtAmountToPay.Text = ""
        End If
        If Val(txtAmountToPay.Text) > Val(LCurrency.getValue(txtAmountDue.Text)) Then
            MsgBox("Invalid amount")
            txtAmountToPay.Text = ""
            btnPay.Enabled = False
        Else
            btnPay.Enabled = True
        End If
    End Sub
    Private Sub txtVendor_MouseEnter(sender As Object, e As EventArgs) Handles txtVendor.MouseEnter
        txtVendor.Text = ""
        txtCode.Text = ""
        dtgrdInvoices.Rows.Clear()
        clearFields()
        pnlInvoice.Enabled = False
        pnlAmount.Enabled = False

        Dim list As New List(Of String)
        Dim mySource As New AutoCompleteStringCollection
        Dim supplier As New Supplier
        list = supplier.getSuppliers(txtVendor.Text)
        mySource.AddRange(list.ToArray)
        txtVendor.AutoCompleteCustomSource = mySource
        txtVendor.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtVendor.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub
    Private Sub clearFields()
        txtInvoiceNo.Text = ""
        txtInvoiceDate.Text = ""
        txtInvoiceTotal.Text = ""
        txtAmountPayed.Text = ""
        txtAmountDue.Text = ""
        txtStatus.Text = ""
        txtAmountToPay.Text = ""
    End Sub
    Private Sub lockInvoice()
        pnlInvoice.Enabled = False
        pnlAmount.Enabled = False
    End Sub
    Private Sub unlockInvoice()
        pnlInvoice.Enabled = True
        pnlAmount.Enabled = True
    End Sub
    Private Function pay(amount As Double, code As String, invoiceNo As String)
        Dim paid As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'Dim reader As MySqlDataReader
            'edit department
            Dim codeQuery As String = "UPDATE `invoice_book` SET `amount_paid`=`amount_paid`+" + amount.ToString + ",`amount_due`=`amount_due`-" + amount.ToString + ",`status`='PAID' WHERE `vendor_id`='" + (New Supplier).getSupplierID(txtCode.Text, "") + "' AND `invoice_no`='" + txtInvoiceNo.Text + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            paid = True
        Catch ex As Exception
            MsgBox(ex.StackTrace)
            paid = False
        End Try
        Return paid
    End Function
    Private Function searchInvoice(code As String, invoiceNo As String)
        Dim found As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `id`, `invoice_no`, `vendor_id`, `date`, `total`, `amount_paid`, `amount_due`, `status` FROM `invoice_book` WHERE `vendor_id`='" + (New Supplier).getSupplierID(txtCode.Text, "") + "' AND `invoice_no`='" + invoiceNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim id As String = ""
            Dim vendorId As String = ""
            Dim _date As String = ""
            Dim total As Double = 0
            Dim amountPayed As Double = 0
            Dim amountDue As Double = 0
            Dim status As String = ""

            While reader.Read
                txtInvoiceDate.Text = reader.GetString("date")
                txtInvoiceTotal.Text = reader.GetString("total")
                txtAmountPayed.Text = LCurrency.displayValue(reader.GetString("amount_paid"))
                txtAmountDue.Text = LCurrency.displayValue(reader.GetString("amount_due"))
                txtStatus.Text = reader.GetString("status")
                found = True
                txtInvoiceTotal.ReadOnly = True
                Exit While
            End While
            conn.Clone()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        If found = True Then
            pnlAmount.Enabled = True
            btnDelete.Enabled = True
            txtInvoiceNo.Enabled = False
            btnSave.Enabled = True
        Else
            pnlAmount.Enabled = False
            btnDelete.Enabled = False
            txtInvoiceNo.Enabled = True
            btnSave.Enabled = False
            clearFields()
        End If
        Return found
    End Function
    Private Function deleteInvoice(code As String, invoiceNo As String)
        Dim deleted As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE  FROM `invoice_book` WHERE `vendor_id`='" + (New Supplier).getSupplierID(txtCode.Text, "") + "' AND `invoice_no`='" + invoiceNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Clone()
            deleted = True
            clearFields()
        Catch ex As Exception
            deleted = False
            MsgBox(ex.Message)
        End Try
        _refresh()
        Return deleted
    End Function
    Private Sub loadInvoices(code As String)
        dtgrdInvoices.Rows.Clear()
        'load invoices
        Dim totalInvoices As Double = 0
        Dim totalPayed As Double = 0
        Dim totalDue As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `id`, `invoice_no`, `vendor_id`, `date`, `total`, `amount_paid`, `amount_due`, `status` FROM `invoice_book` WHERE `vendor_id`='" + (New Supplier).getSupplierID(txtCode.Text, "") + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim id As String = ""
            Dim invoiceNo As String = ""
            Dim vendorId As String = ""
            Dim _date As String = ""
            Dim total As Double = 0
            Dim amountPayed As Double = 0
            Dim amountDue As Double = 0
            Dim status As String = ""


            While reader.Read

                id = reader.GetString("id")
                invoiceNo = reader.GetString("invoice_no")
                vendorId = reader.GetString("vendor_id")
                _date = reader.GetString("date")
                total = reader.GetString("total")
                amountPayed = reader.GetString("amount_paid")
                amountDue = reader.GetString("amount_due")
                status = reader.GetString("status")

                totalInvoices = totalInvoices + total
                totalPayed = totalPayed + amountPayed
                totalDue = totalDue + amountDue

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = invoiceNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = _date
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(total)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(amountPayed)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(amountDue)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = status
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = id
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdInvoices.Rows.Add(dtgrdRow)


            End While
            conn.Clone()

        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        txtTotalInvoices.Text = LCurrency.displayValue(totalInvoices.ToString)
        txtTotalPaid.Text = LCurrency.displayValue(totalPayed.ToString)
        txtTotalDue.Text = LCurrency.displayValue(totalDue.ToString)
    End Sub
    Private Function saveInvoice()

        Return vbNull
    End Function
    Private Function searchVendor(name As String, code As String)
        Dim found As Boolean = False
        Dim query As String = ""
        If name <> "" Then
            query = "SELECT `supplier_id`, `supplier_code`, `supplier_name` FROM `supplier` WHERE `supplier_name`='" + name + "'"
        Else
            query = "SELECT `supplier_id`, `supplier_code`, `supplier_name` FROM `supplier` WHERE `supplier_id`='" + (New Supplier).getSupplierID(code, "") + "'"
        End If
        Try
            Dim command As New MySqlCommand()
            Dim conn As New MySqlConnection(Database.conString)
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim itemreader As MySqlDataReader = command.ExecuteReader()
            If itemreader.HasRows = True Then
                While itemreader.Read
                    txtVendor.Text = itemreader("supplier_name").ToString
                    txtCode.Text = itemreader("supplier_code").ToString
                    loadInvoices(txtVendor.Text)
                    pnlInvoice.Enabled = True
                End While
                found = True
            Else
                found = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return found
    End Function
    Dim STATUS As String = ""
    Private Function isExist(vendorId As String, invoiceNo As String)
        Dim exist As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT * FROM `invoice_book` WHERE `vendor_id`='" + (New Supplier).getSupplierID(txtCode.Text, "") + "' AND `invoice_no`='" + txtInvoiceNo.Text + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                exist = True
                Exit While
            End While

            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return exist
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearchVendor.Click
        searchVendor(txtVendor.Text, txtCode.Text)
    End Sub

    Private Sub txtVendor_TextChanged(sender As Object, e As EventArgs) Handles txtVendor.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtInvoiceTotal.ReadOnly = False
        txtInvoiceNo.ReadOnly = False
        txtInvoiceDate.Enabled = True
        txtInvoiceTotal.ReadOnly = False
        txtInvoiceNo.ReadOnly = False
        btnSearchInvoice.Enabled = False
        btnDelete.Enabled = False
        STATUS = "NEW"
        clearFields()
        dtgrdInvoices.Enabled = False
        If txtCode.Text = "" Then
            btnSave.Enabled = False
            MsgBox("Please select a vendor/Supplier")
        Else
            btnSave.Enabled = True
        End If
    End Sub
    Private Function saveInvoice(invoiceNo As String, invoiceDate As String, invoiceTotal As String)
        Dim saved As Boolean = False
        If STATUS = "NEW" And isExist((New Supplier).getSupplierID(txtCode.Text, ""), txtInvoiceNo.Text) = False Then
            'save invoice
            If Val(txtInvoiceTotal.Text) <= 0 Or txtInvoiceDate.Text = "" Or txtInvoiceNo.Text = "" Then
                MsgBox("Operation failed. Invalid fields")
                Return saved
                Exit Function
            End If
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim codeQuery As String = "INSERT INTO `invoice_book`(`invoice_no`, `vendor_id`, `date`, `total`, `amount_paid`, `amount_due`, `status`) VALUES (@invoice_no,@vendor_id,@date,@total,@amountPayed,@amount_due,@status)"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@invoice_no", txtInvoiceNo.Text)
                command.Parameters.AddWithValue("@vendor_id", (New Supplier).getSupplierID(txtCode.Text, ""))
                command.Parameters.AddWithValue("@date", txtInvoiceDate.Text)
                command.Parameters.AddWithValue("@total", txtInvoiceTotal.Text)
                command.Parameters.AddWithValue("@amountPayed", 0)
                command.Parameters.AddWithValue("@amount_due", txtInvoiceTotal.Text)
                command.Parameters.AddWithValue("@status", "PENDING")
                command.ExecuteNonQuery()
                conn.Close()
                MsgBox("New Invoice saved")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        ElseIf STATUS = "NEW" Then
            MsgBox("Invoice already exist")
        End If

        If STATUS = "EDIT" And isExist((New Supplier).getSupplierID(txtCode.Text, ""), txtInvoiceNo.Text) = True Then
            'save invoice
            If Val(txtInvoiceTotal.Text) <= 0 Or txtInvoiceDate.Text = "" Or txtInvoiceNo.Text = "" Then
                MsgBox("Operation failed. Invalid fields")
                Return saved
                Exit Function
            End If
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim codeQuery As String = "UPDATE `invoice_book` SET`date`='" + txtInvoiceDate.Text + "',`total`='" + txtInvoiceTotal.Text + "' WHERE `invoice_no`='" + txtInvoiceNo.Text + "' AND `vendor_id`='" + (New Supplier).getSupplierID(txtCode.Text, "") + "'"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                conn.Close()
                saved = True
                MsgBox("Invoice updated")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        ElseIf STATUS = "EDIT" Then
            MsgBox("Invoice does not exist")
        End If

        loadInvoices(txtCode.Text)
        Return saved
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        saveInvoice(txtInvoiceNo.Text, txtInvoiceDate.Text, txtInvoiceTotal.Text)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        txtInvoiceNo.ReadOnly = False
        txtInvoiceDate.Enabled = True
        txtInvoiceTotal.ReadOnly = False

        clearFields()
        btnDelete.Enabled = False
        btnSave.Enabled = False
        btnSearchInvoice.Enabled = True
        txtInvoiceNo.Enabled = True
        STATUS = "EDIT"
        dtgrdInvoices.Enabled = True
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearFields()
        btnDelete.Enabled = False
        txtInvoiceNo.Enabled = True
    End Sub

    Private Sub btnSearchInvoice_Click(sender As Object, e As EventArgs) Handles btnSearchInvoice.Click
        If searchInvoice(txtCode.Text, txtInvoiceNo.Text) = False Then
            MsgBox("No matching record")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim res As Integer = MsgBox("Are you sure you want to remove the selected invoice? This action can not be undone.", vbYesNoCancel + vbQuestion, "Delete invoice")
        If res = vbYes Then
            deleteInvoice(txtCode.Text, txtInvoiceNo.Text)
        End If
    End Sub
    Private Sub _refresh()
        loadInvoices(txtCode.Text)
    End Sub

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        Dim res As Integer = MsgBox("Confirm payment?", vbYesNoCancel + vbQuestion, "Confirm payment")
        If res = vbYes Then
            If (pay(Val(txtAmountToPay.Text), txtCode.Text, txtInvoiceNo.Text)) Then
                MsgBox("Operation successiful")
                txtAmountToPay.Text = ""
                searchInvoice(txtCode.Text, txtInvoiceNo.Text)
                _refresh()
            Else
                MsgBox("Could not complete payment")
            End If

        End If
    End Sub

    Private Sub txtInvoiceTotal_TextChanged(sender As Object, e As EventArgs) Handles txtInvoiceTotal.TextChanged

    End Sub

    Private Sub dtgrdInvoices_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdInvoices.CellContentClick

    End Sub

    Private Sub dtgrdInvoices_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdInvoices.RowHeaderMouseClick
        Try
            If dtgrdInvoices.CurrentRow.Index >= 0 Then
                txtInvoiceNo.Text = dtgrdInvoices.Item(0, e.RowIndex).Value.ToString
                searchInvoice(txtCode.Text, txtInvoiceNo.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Dispose()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub txtTotalInvoices_TextChanged(sender As Object, e As EventArgs) Handles txtTotalInvoices.TextChanged

    End Sub

    Private Sub txtTotalPaid_TextChanged(sender As Object, e As EventArgs) Handles txtTotalPaid.TextChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub txtTotalDue_TextChanged(sender As Object, e As EventArgs) Handles txtTotalDue.TextChanged

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
        style.Font.Name = "Times New Roman"
        style.Font.Size = 9
        'Create a new style called Reference based on style Normal
        style = doc.Styles.AddStyle("Reference", "Normal")
        style.ParagraphFormat.SpaceBefore = "5mm"
        style.ParagraphFormat.SpaceAfter = "5mm"
        style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right)

    End Sub
    Private Sub createDocument(doc As Document)
        'Each MigraDoc document needs at least one section.
        Dim section As Section = doc.AddSection()
        Dim paragraph As Paragraph
        'Put a logo in the header
        'code missing
        doc.FootnoteStartingNumber() = 1
        'create headrer
        paragraph = section.Headers.Primary.AddParagraph()
        paragraph.AddText("Vendor Invoices")
        paragraph.Format.Font.Size = 9
        paragraph.Format.Alignment = ParagraphAlignment.Center
        'create footer
        paragraph = section.Footers.Primary.AddParagraph()
        paragraph.AddText("")
        paragraph = section.Footers.Primary.AddParagraph()
        Dim _datetime As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        paragraph.AddText("Printed :" & _datetime + " By :" & User.CURRENT_ALIAS & " From :" & Company.NAME)
        paragraph.Format.Font.Size = 9
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Color = Colors.Blue
        paragraph = section.Footers.Primary.AddParagraph()
        paragraph.AddPageField()
        paragraph.AddText(" of ")
        paragraph.AddNumPagesField()
        paragraph.Format.Alignment = ParagraphAlignment.Right
        'Create the text frame for the address

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText(Company.NAME, TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText(Company.PHYSICAL_ADDRESS, TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText(Company.NAME, TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Vendor Invoices", TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("TIN:        " + Company.TIN)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("VRN:        " + Company.VRN)
        paragraph.Format.Font.Size = 8

        paragraph = section.AddParagraph()

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Vendor: " + txtVendor.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Code:   " + txtCode.Text)
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

        column = table.AddColumn("2.2cm")
        column.Format.Alignment = ParagraphAlignment.Left


        column = table.AddColumn("2.2cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("2.2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.2cm")
        column.Format.Alignment = ParagraphAlignment.Left

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Font.Size = 8
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Inv No")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Date")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Inv Total")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Amount Paid")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Center
        row.Cells(4).AddParagraph("Amount Due")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Center
        row.Cells(5).AddParagraph("Inv Status")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Center



        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0

        For i As Integer = 0 To dtgrdInvoices.RowCount - 1
            Dim invNo As String = dtgrdInvoices.Item(0, i).Value.ToString
            Dim _date As String = dtgrdInvoices.Item(1, i).Value.ToString
            Dim invTotal As String = LCurrency.displayValue(dtgrdInvoices.Item(2, i).Value.ToString)
            Dim amountPaid As String = LCurrency.displayValue(dtgrdInvoices.Item(3, i).Value.ToString)
            Dim amountDue As String = LCurrency.displayValue(dtgrdInvoices.Item(4, i).Value.ToString)
            Dim status As String = dtgrdInvoices.Item(5, i).Value.ToString

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 7
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(invNo)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(_date)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(invTotal)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Right
            row.Cells(3).AddParagraph(amountPaid)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Right
            row.Cells(4).AddParagraph(amountDue)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Right
            row.Cells(5).AddParagraph(status)
            row.Cells(5).Format.Alignment = ParagraphAlignment.Left


            table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Next

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
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
        row.Cells(5).AddParagraph()
        row.Cells(5).Format.Alignment = ParagraphAlignment.Right

        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)


        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Total Invoices:  " + LCurrency.displayValue(txtTotalInvoices.Text))
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Total Paid:      " + LCurrency.displayValue(txtTotalPaid.Text))
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Total Due:       " + LCurrency.displayValue(txtTotalDue.Text))
        paragraph.Format.Font.Size = 8

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim document As Document = New Document

        document.Info.Title = "Vendor Invoices"
        document.Info.Subject = "Vendor Invoices"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Invoices " & txtCode.Text & " " & txtVendor.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        frmAllInvoices.ShowDialog()
    End Sub

    Private Sub frmInvoiceBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


End Class