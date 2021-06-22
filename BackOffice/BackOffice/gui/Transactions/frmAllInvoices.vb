Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmAllInvoices
    Private Sub frmAllInvoices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadInvoices()
    End Sub
    Private Sub loadInvoices()
        dtgrdInvoices.Rows.Clear()
        'load invoices
        Dim totalInvoices As Double = 0
        Dim totalPayed As Double = 0
        Dim totalDue As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `id`, `invoice_no`, `vendor_id`, `date`, SUM(`total`) AS `total`, SUM(`amount_paid`)AS `amount_paid`, SUM(`amount_due`)AS `amount_due`, `status` FROM `invoice_book` GROUP BY `vendor_id`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim id As String = ""
            Dim invoiceNo As String = ""
            Dim vendorId As String = ""
            Dim vendorCode As String = ""
            Dim vendor As String = ""
            Dim _date As String = ""
            Dim total As Double = 0
            Dim amountPayed As Double = 0
            Dim amountDue As Double = 0
            Dim status As String = ""


            While reader.Read

                id = reader.GetString("id")
                invoiceNo = reader.GetString("invoice_no")
                vendorId = reader.GetString("vendor_id")
                vendorCode = (New Supplier).getSupplierCode(vendorId, "")
                vendor = (New Supplier).getSupplierName(vendorId, "")
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
                dtgrdCell.Value = vendorCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = vendor
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
        paragraph.AddText("Vendors Invoice Summary")
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
        paragraph.AddFormattedText("Vendors Invoice Summary", TextFormat.Bold)
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

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left


        column = table.AddColumn("6cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("2.6cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.6cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.6cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Font.Size = 8
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Code")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Vendor")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Inv Total")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Amount Paid")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Center
        row.Cells(4).AddParagraph("Amount Due")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Center




        table.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0

        For i As Integer = 0 To dtgrdInvoices.RowCount - 1
            Dim code As String = dtgrdInvoices.Item(0, i).Value.ToString
            Dim vendor As String = dtgrdInvoices.Item(1, i).Value.ToString
            Dim invTotal As String = LCurrency.displayValue(dtgrdInvoices.Item(2, i).Value.ToString)
            Dim amountPaid As String = LCurrency.displayValue(dtgrdInvoices.Item(3, i).Value.ToString)
            Dim amountDue As String = LCurrency.displayValue(dtgrdInvoices.Item(4, i).Value.ToString)

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 7
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(code)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(vendor)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(invTotal)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Right
            row.Cells(3).AddParagraph(amountPaid)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Right
            row.Cells(4).AddParagraph(amountDue)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Right



            table.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
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

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Format.Font.Bold = True
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph(LCurrency.displayValue(txtTotalInvoices.Text))
        row.Cells(2).Format.Alignment = ParagraphAlignment.Right
        row.Cells(3).AddParagraph(LCurrency.displayValue(txtTotalPaid.Text))
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(4).AddParagraph(LCurrency.displayValue(txtTotalDue.Text))
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right


        table.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)



    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim document As Document = New Document

        document.Info.Title = "Invoice Summary Report"
        document.Info.Subject = "Invoice Summary Report"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Vendors Invoice Summary " & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub
End Class