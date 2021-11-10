Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmExpenses
    Dim EDIT_MODE As String = ""
    Private GL_USERNAME As String = ""
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Function clear()

        txtExpenseNo.Text = ""
        txtExpenseDate.Text = ""
        txtAmount.Text = ""
        txtDescription.Text = ""
        Return vbNull
    End Function
    Private Function lock()

        Return vbNull
    End Function
    Private Function unlock()


        Return vbNull
    End Function


    Private Function refreshList(dateStart As String, dateEnd As String)

        dtgrdExpensesList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `expense_id`, `expense_no`, `date_time`, `date`, `amount`, `description`, `user_id`, `category` FROM `expenses` WHERE `date` BETWEEN '" + dateStart + "' AND '" + dateEnd + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            While reader.Read

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("expense_id")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("expense_no")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("date")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(reader.GetString("amount"))
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("description")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdExpensesList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        EDIT_MODE = "NEW"
        '  txtId.Text = ""
        btnEdit.Enabled = True
        '  btnDelete.Enabled = False
        btnSave.Enabled = True
        '  btnSearch.Enabled = False
        clear()
        unlock()
        txtExpenseNo.ReadOnly = True
        txtExpenseNo.Text = generateExpense()
        txtExpenseDate.Text = Day.DAY
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validateEntries() <> True Then
            Exit Sub
        End If

        If EDIT_MODE = "NEW" Then
            'User.GL_STATUS = "ACTIVE"

            Dim added As Boolean = False
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim Query As String = "INSERT INTO `expenses`(`expense_no`, `date`, `amount`, `description`, `user_id`, `category`) VALUES (@expense_no,@date,@amount,@description,@user_id,@category)"

                conn.Open()
                command.CommandText = Query
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@expense_no", txtExpenseNo.Text)
                command.Parameters.AddWithValue("@date", txtExpenseDate.Text)
                command.Parameters.AddWithValue("@amount", txtAmount.Text)
                command.Parameters.AddWithValue("@description", txtDescription.Text)
                command.Parameters.AddWithValue("@user_id", User.CURRENT_USER_ID)
                command.Parameters.AddWithValue("@category", "NAN")

                command.ExecuteNonQuery()
                conn.Close()
                added = True
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                EDIT_MODE = ""


                MsgBox("Expense saved successifully", vbOKOnly + vbInformation, "Success")
            Catch ex As MySqlException
                added = False
                MsgBox("Could not add Record. Duplicate entries in expense no ", vbOKOnly + vbCritical, "Error: Duplicate entry")
            Catch ex As Exception
                added = False
                MsgBox(ex.Message)
            End Try

        Else

            Dim edited As Boolean = False
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim Query As String = "UPDATE `expenses` SET `amount`='" + txtAmount.Text + "',`description`='" + txtDescription.Text + "',`user_id`='" + User.CURRENT_USER_ID + "' WHERE `expense_no`='" + txtExpenseNo.Text + "'"

                conn.Open()
                command.CommandText = Query
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                conn.Close()
                edited = True
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                EDIT_MODE = ""
                MsgBox("Expense Edited successifully", vbOKOnly + vbInformation, "Success")
            Catch ex As MySqlException
                edited = False
                MsgBox("Could not edit record. Duplicate or no entries in expense no ", vbOKOnly + vbCritical, "Error: Duplicate entry")
            Catch ex As Exception
                edited = False
                MsgBox(ex.Message + ex.GetType.ToString)
            End Try

        End If
        refreshList(txtExpenseDate.Text, txtExpenseDate.Text)
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected expense? The record will be completely removed from the system", vbYesNo + vbQuestion, "Delete Sales Person?")
        If res = DialogResult.Yes Then

            Dim deleted As Boolean = False
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim Query As String = "DELETE FROM `expenses` WHERE `expense_no`='" + txtExpenseNo.Text + "'"
                conn.Open()
                command.CommandText = Query
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                conn.Close()
                deleted = True

            Catch ex As Exception
                deleted = False
                MsgBox(ex.Message + ex.GetType.ToString)
            End Try

        End If
        ' btnDelete.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = False
        unlock()
        clear()
    End Sub

    Private Function validateEntries() As Boolean
        Dim valid As Boolean = True
        Dim errorMessage As String = ""


        Return valid
    End Function



    Public Function generateExpense() As String
        Dim no As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `expense_id` FROM `expenses` ORDER BY `expense_id` DESC LIMIT 1"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                no = (Val(reader.GetString("expense_id")) + 1).ToString
                Exit While
            End While
            If no = "" Then
                no = "1"
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return "EXP-" + no
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub
    Private Sub _clear()

    End Sub

    Private Sub MaterialStockStatusToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ' generate()
        If dtgrdExpensesList.RowCount = 0 Then
            MsgBox("Nothing to print")
            Exit Sub
        End If

        Dim document As Document = New Document

        document.Info.Title = "Expenses"
        document.Info.Subject = "Expenses"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Expenses.pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)
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
        ''paragraph = section.Headers.Primary.AddParagraph()
        ''paragraph.AddFormattedText(Company.NAME, TextFormat.Bold)
        ''paragraph.Format.Font.Size = 9
        ''paragraph.Format.Font.Color = Colors.Green
        ''paragraph.Format.Alignment = ParagraphAlignment.Center
        'create footer
        ' 'paragraph = section.Footers.Primary.AddParagraph()
        '' paragraph.AddText("")
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
        'Create the text frame for the address

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText(Company.NAME, TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText(Company.PHYSICAL_ADDRESS)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText(Company.POST_CODE)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Tel: " + Company.TELEPHONE + " Mob:" + Company.MOBILE)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Email: " + Company.EMAIL)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Material stock status", TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph.AddText("Date: " + Day.DAY)
        paragraph.Format.Alignment = ParagraphAlignment.Left





        'Add the print date field
        paragraph = section.AddParagraph()
        paragraph.Format.SpaceBefore = "1cm"
        paragraph.Style = "Reference"
        paragraph.AddTab()
        paragraph.AddText("Created: ")
        paragraph.AddDateField("dd.MM.yyyy")

        'Create the item table
        Dim table As Tables.Table = section.AddTable()
        table.Style = "Table"
        ' table.Borders.Color = TableBorder
        table.Borders.Width = 0.25
        table.Borders.Left.Width = 0.5
        table.Borders.Right.Width = 0.5
        table.Rows.LeftIndent = 0

        'Before you can add a row, you must define the columns
        Dim column As Tables.Column

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("5.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row As Tables.Row

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Font.Size = 8
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.LightGray
        row.Cells(0).AddParagraph("Expense No")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Date")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Amount")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Description")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left



        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0


        For i As Integer = 0 To dtgrdExpensesList.RowCount - 1
            Dim no As String = dtgrdExpensesList.Item(0, i).Value.ToString
            Dim expenseDate As String = dtgrdExpensesList.Item(1, i).Value.ToString
            Dim amount As String = dtgrdExpensesList.Item(2, i).Value.ToString
            Dim description As String = dtgrdExpensesList.Item(3, i).Value.ToString

            If Val(LCurrency.getValue(amount)) > 0 Then
                totalAmount = totalAmount + Val(amount)
            End If

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 8
            row.Height = "5mm"
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.LightGray
            row.Cells(0).AddParagraph(no)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(expenseDate)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(amount)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Right
            row.Cells(3).AddParagraph(description)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left

            table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Next
        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = False
        row.Format.Font.Size = 8
        row.Height = "5mm"
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.LightGray
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Total")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph(LCurrency.displayValue(totalAmount))
        row.Cells(2).Format.Alignment = ParagraphAlignment.Right
        row.Cells(3).AddParagraph("")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left

    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        If Not IsNumeric(LCurrency.getValue(txtAmount.Text)) Then
            txtAmount.Text = ""
        End If
        If Val(LCurrency.getValue(txtAmount.Text)) < 0 Then
            txtAmount.Text = ""
        End If
    End Sub

    Private Sub frmExpenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtExpenseNo.Text = ""
        txtExpenseDate.Text = ""
        txtAmount.Text = ""
        txtDescription.Text = ""
        dtgrdExpensesList.Rows.Clear()
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        refreshList(dateStart.Text, dateEnd.Text)
    End Sub

    Private Sub dtgrdList_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdExpensesList.RowHeaderMouseClick
        clear()
        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            row = dtgrdExpensesList.CurrentRow.Index
            col = dtgrdExpensesList.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try

        row = dtgrdExpensesList.CurrentRow.Index
        search(dtgrdExpensesList.Item(1, row).Value.ToString)
    End Sub
    Private Function search(expenceNo As String) As Boolean
        Dim found = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT `expense_id`, `expense_no`, `date_time`, `date`, `amount`, `description`, `user_id`, `category`, `status` FROM `expenses` WHERE `expense_no`='" + expenceNo + "'"

            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtExpenseNo.Text = reader.GetString("expense_no")
                txtExpenseDate.Text = reader.GetString("date")
                txtAmount.Text = reader.GetString("amount")
                txtDescription.Text = reader.GetString("description")

                found = True
                Exit While
            End While
            If found = True Then
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                '   btnDelete.Enabled = True
            Else
                MsgBox("No matching record", vbOKOnly + vbCritical, "Error: Not found")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function
End Class