Imports Devart.Data.MySql
Imports Microsoft.Office.Interop
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmDebtPayment
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
        paragraph.AddFormattedText("Debt Payment Report", TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("From: " + dateStart.Text + " to :" + dateEnd.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        If cmbSalesPersons.Text = "" Then
            paragraph.AddFormattedText("S/M Officer: <--All-->")
        Else
            paragraph.AddFormattedText("S/M Officer:       " + cmbSalesPersons.Text)
        End If
        paragraph.Format.Font.Size = 8



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
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.0cm")
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
        row.Cells(0).AddParagraph("Payment Date")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Deficit Date")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Issue No")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Initial Amount")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("Amount Paid")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph("Balance")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left


        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0


        For i As Integer = 0 To dtgrdList.RowCount - 1
            Dim _date As String = dtgrdList.Item(0, i).Value.ToString
            Dim deficitDate As String = dtgrdList.Item(1, i).Value.ToString
            Dim issueNo As String = dtgrdList.Item(2, i).Value.ToString
            Dim initialAmount As String = dtgrdList.Item(3, i).Value.ToString
            Dim amountPaid As String = dtgrdList.Item(4, i).Value.ToString
            Dim balance As String = dtgrdList.Item(5, i).Value.ToString

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 8
            row.Height = "5mm"
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.LightGray
            row.Cells(0).AddParagraph(_date)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(deficitDate)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(issueNo)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(initialAmount)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Right
            row.Cells(4).AddParagraph(amountPaid)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Right
            row.Cells(5).AddParagraph(balance)
            row.Cells(5).Format.Alignment = ParagraphAlignment.Right

            table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
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
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Total Paid")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph(txtTotalPaid.Text)
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right
        row.Cells(5).AddParagraph("")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Right

        table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

    End Sub


    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        generate()
    End Sub
    Private Sub generate()
        refreshList()
    End Sub
    Private Function refreshList()
        dtgrdList.Rows.Clear()

        Dim totalPaid As Double = 0

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""


            query = "SELECT
                        `id`,
                        `date`,
                        `issue_no`, 
                        `initial_balance`, 
                        `amount`,
                        `current_balance`, 
                        `user_id`,
                        `sales_person_id`, 
                        `remarks` 
                    FROM
	                    `debt_payment`
                    WHERE 
	                    `date`BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' 
                    ORDER BY `date`"

            If cmbSalesPersons.Text <> "" Then
                Dim salesPersonId As String = (New PackingList).getSalesPersonId(cmbSalesPersons.Text)



                query = "SELECT
                            `id`,
                            `date`,
                            `issue_no`, 
                            `initial_balance`, 
                            `amount`,
                            `current_balance`, 
                            `user_id`,
                            `sales_person_id`, 
                            `remarks` 
                        FROM
	                        `debt_payment`
                        WHERE 
	                        `date`BETWEEN '2021-06-01' AND '2021-06-12' AND `sales_person_id`='" + salesPersonId + "'
                        ORDER BY `date`"

            End If

            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()


            While reader.Read
                Dim _date As String = reader.GetString("date")
                Dim issueNo As String = reader.GetString("issue_no")
                Dim issueDate As String = (New PackingList).getPackingListDate(issueNo)
                Dim initialBalance As String = reader.GetString("initial_balance")
                Dim amount As String = reader.GetString("amount")
                Dim balance As String = reader.GetString("current_balance")

                totalPaid = totalPaid + Val(amount)

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = _date
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = issueDate
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = issueNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(initialBalance)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(amount)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(balance)
                dtgrdRow.Cells.Add(dtgrdCell)


                dtgrdList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
            txtTotalPaid.Text = LCurrency.displayValue(totalPaid.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return vbNull
    End Function
    Dim list As String = ""

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Sub loadSalesPersons()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            Dim suppcommand As New MySqlCommand()
            Dim supplierQuery As String = "SELECT
                                                `id`,
                                                `full_name`
                                            FROM
                                                `sales_persons`"
            conn.Open()
            suppcommand.CommandText = supplierQuery
            suppcommand.Connection = conn
            suppcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = suppcommand.ExecuteReader
            cmbSalesPersons.Items.Clear()
            cmbSalesPersons.Items.Add("")
            If reader.HasRows Then
                While reader.Read
                    cmbSalesPersons.Items.Add(reader.GetString("full_name"))
                End While
            End If
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try
    End Sub

    Private Sub frmSalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim item As New Item
        longList = item.getItems()
        loadSalesPersons()
    End Sub
    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)




    Private Sub clearFields()

        txtTotalPaid.Text = ""
        dtgrdList.Rows.Clear()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        cmbSalesPersons.Text = ""
        dtgrdList.Rows.Clear()
        clearFields()

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        generate()
        If dtgrdList.RowCount = 0 Then
            MsgBox("Nothing to print")
            Exit Sub
        End If

        Dim document As Document = New Document

        document.Info.Title = "Debt Payment Report"
        document.Info.Subject = "Debt Payment Report"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Debt Payment Report " & dateStart.Text & dateEnd.Text & cmbSalesPersons.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)
    End Sub

    Private Sub cmbSalesPersons_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSalesPersons.SelectedIndexChanged
        clearFields()
    End Sub

    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click
        If dtgrdList.RowCount = 0 Then
            MsgBox("Nothing to export")
            Exit Sub
        End If
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
        shXL.Cells(r, 1).Value = "From: " + dateStart.Text
        shXL.Cells(r, 2).Value = "To: " + dateEnd.Text

        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A1", "B1")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        r = r + 1
        ' Add table headers going cell by cell.
        If cmbSalesPersons.Text = "" Then
            shXL.Cells(r, 1).Value = "S/M Officer: <--All-->"
        Else
            shXL.Cells(r, 1).Value = "S/M Officer: " + cmbSalesPersons.Text
        End If



        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A1")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        r = r + 2
        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "Payment Date"
        shXL.Cells(r, 2).Value = "Deficit Date"
        shXL.Cells(r, 3).Value = "Issue No"
        shXL.Cells(r, 4).Value = "Initial Amount"
        shXL.Cells(r, 5).Value = "Amount Paid"
        shXL.Cells(r, 6).Value = "Balance"
        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A4", "F4")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        r = r + 1
        'raXL = shXL.Range("C1", "C7")
        'raXL.Formula = "=A1 & "" "" & B1"
        'Dim r As Integer = 3
        For i As Integer = 0 To dtgrdList.RowCount - 1
            With shXL
                .Cells(r, 1).Value = dtgrdList.Item(0, i).Value
                .Cells(r, 2).Value = dtgrdList.Item(1, i).Value
                .Cells(r, 3).Value = dtgrdList.Item(2, i).Value
                .Cells(r, 4).Value = dtgrdList.Item(3, i).Value
                .Cells(r, 5).Value = dtgrdList.Item(4, i).Value
                .Cells(r, 6).Value = dtgrdList.Item(5, i).Value
            End With
            r = r + 1
        Next

        r = r + 1
        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "Total Paid"
        shXL.Cells(r, 2).Value = txtTotalPaid.Text


        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "E1")
        raXL.EntireColumn.AutoFit()
        ' Make sure Excel is visible and give the user control
        ' of Excel's lifetime.
        appXL.Visible = True
        appXL.UserControl = True
        ' Release object references.
        raXL = Nothing
        shXL = Nothing
        wbXl = Nothing
        appXL.Quit()
        appXL = Nothing
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

    End Sub

    Private Sub cmbDescription_KeyUp(sender As Object, e As KeyEventArgs)

    End Sub
End Class