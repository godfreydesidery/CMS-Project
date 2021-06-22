Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmPettyCash
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Function refreshList()
        dtgrdList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            'Dim codeQuery As String = "SELECT `date`,SUM(`amount`) AS total_amount,SUM(`discount`) AS total_discount,SUM(`tax_return`) AS total_tax FROM `sale` WHERE `date`>='" + dateStart.Text + "' AND `date`<='" + dateEnd.Text + "' GROUP BY `date`"
            Dim codeQuery As String = "SELECT `sn`, `till_no`, DATE(`date_time`) AS `date`, `amount`, `details` FROM `petty_cash` WHERE  DATE(`date_time`)>='" + dateStart.Text + "' AND DATE(`date_time`)<='" + dateEnd.Text + "'"

            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim date_ As String = ""
            Dim till As String = ""
            Dim amount As String = ""
            Dim details As String = ""

            Dim total As Double = 0



            While reader.Read

                date_ = reader.GetString("date")
                till = reader.GetString("till_no")
                amount = LCurrency.displayValue(reader.GetString("amount"))
                details = reader.GetString("details")

                total = total + Val(reader.GetString("amount"))

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = date_
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = till
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = amount
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = details
                dtgrdRow.Cells.Add(dtgrdCell)


                dtgrdList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
            txtTotalSales.Text = LCurrency.displayValue(total.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click

        refreshList()
    End Sub

    Private Sub frmDailySalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtgrdList.Rows.Clear()
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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        refreshList()
        Dim startDate As String = dateStart.Text
        Dim endDate As String = dateEnd.Text

        Dim document As Document = New Document

        document.Info.Title = "Petty Cash Report"
        document.Info.Subject = "Petty Cash Report"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Petty Cash Report " & dateStart.Text & " to " & dateEnd.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)

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
        paragraph.AddFormattedText("Petty Cash Report", TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()
        paragraph.AddText("From:  " + dateStart.Text + "  To:  " + dateEnd.Text)
        paragraph.Format.Alignment = ParagraphAlignment.Left
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green

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

        column = table.AddColumn("3cm")
        column.Format.Alignment = ParagraphAlignment.Center


        column = table.AddColumn("3cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("3cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("6cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.HeadingFormat = True
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Date")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Till")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Amount")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Center
        row.Cells(3).AddParagraph("Details")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left


        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalQty As Double = 0

        For i As Integer = 0 To dtgrdList.RowCount - 1

            Dim date_ As String = dtgrdList.Item(0, i).Value
            Dim till As String = dtgrdList.Item(1, i).Value
            Dim amount As String = dtgrdList.Item(2, i).Value
            Dim details As String = dtgrdList.Item(3, i).Value

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(date_)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(till)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(amount)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Right
            row.Cells(3).AddParagraph(details)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left


            table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Next

        row = table.AddRow()
        row.Format.Font.Bold = False
        row.HeadingFormat = False
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        row.Cells(2).AddParagraph("")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Right
        row.Cells(3).AddParagraph("")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right


        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Font.Bold = False
        row.HeadingFormat = False
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Right
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        row.Cells(2).AddParagraph(txtTotalSales.Text)
        row.Cells(2).Format.Alignment = ParagraphAlignment.Right
        row.Cells(2).Format.Font.Bold = True
        row.Cells(3).AddParagraph("")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right


        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

    End Sub

    Private Sub dtgrdList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdList.CellContentClick

    End Sub
End Class