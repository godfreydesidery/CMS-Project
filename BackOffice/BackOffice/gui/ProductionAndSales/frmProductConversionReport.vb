Imports Devart.Data.MySql
Imports Microsoft.Office.Interop
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Public Class frmProductConversionReport
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
        style.Font.Name = "Calibri"
        style.Font.Size = 10
        'Create a new style called Reference based on style Normal
        style = doc.Styles.AddStyle("Reference", "Normal")
        style.ParagraphFormat.SpaceBefore = "5mm"
        style.ParagraphFormat.SpaceAfter = "5mm"
        style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right)

    End Sub
    Private Sub createDocument(doc As Document)
        'Each MigraDoc document needs at least one section.
        Dim section As Section = doc.AddSection()
        section.PageSetup.DifferentFirstPageHeaderFooter = True
        Dim paragraph As Paragraph
        doc.FootnoteStartingNumber() = 1
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
        section.Footers.FirstPage = section.Footers.Primary.Clone()
        'Start of header
        Dim logoPath As String = ""
        Dim logoImage As Image = Nothing
        Dim headerTable As Table = section.Headers.FirstPage.AddTable()
        headerTable.Borders.Width = 0.2
        headerTable.Borders.Left.Width = 0.2
        headerTable.Borders.Right.Width = 0.2
        headerTable.Rows.LeftIndent = 0
        Dim headerColumn As Column
        headerColumn = headerTable.AddColumn("2.2cm")
        headerColumn.Format.Alignment = ParagraphAlignment.Left
        headerColumn = headerTable.AddColumn("0.3cm")
        headerColumn.Format.Alignment = ParagraphAlignment.Left
        headerColumn = headerTable.AddColumn("12cm")
        headerColumn.Format.Alignment = ParagraphAlignment.Left
        Dim headerRow As Row
        headerRow = headerTable.AddRow()
        headerRow.Format.Font.Bold = False
        headerRow.HeadingFormat = True
        headerRow.Format.Font.Size = 9
        headerRow.Format.Alignment = ParagraphAlignment.Center
        headerRow.Borders.Color = Colors.White
        Try
            Dim logo As New System.IO.MemoryStream(CType(Company.LOGO, Byte()))
            logoImage = Image.FromStream(logo)
            logoPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "TempDocumentLogo.png"
            If My.Computer.FileSystem.FileExists(logoPath) Then
                My.Computer.FileSystem.DeleteFile(logoPath)
            End If
            logoImage.Save(logoPath)
            If logo.Length > 0 Then
                headerRow.Cells(0).AddImage(logoPath).Width = "2.2cm"
                headerRow.Cells(0).Format.Alignment = ParagraphAlignment.Left
            End If
        Catch ex As Exception
        End Try
        headerRow.Cells(1).AddParagraph("")
        Dim companyName As New Paragraph
        companyName.AddText(Company.NAME + Environment.NewLine)
        companyName.Format.Font.Bold = True
        companyName.Format.Font.Size = 9
        Dim physicalAddress As New Paragraph
        physicalAddress.AddText(Company.PHYSICAL_ADDRESS + Environment.NewLine)
        physicalAddress.Format.Font.Size = 8
        Dim address As New Paragraph
        address.AddText(Company.ADDRESS + Environment.NewLine)
        address.Format.Font.Size = 8
        Dim postCode As New Paragraph
        postCode.AddText(Company.POST_CODE + Environment.NewLine)
        postCode.Format.Font.Size = 8
        Dim telephone As New Paragraph
        telephone.AddText("Tel: " + Company.TELEPHONE + " Mob:" + Company.MOBILE + Environment.NewLine)
        telephone.Format.Font.Size = 7
        Dim email As New Paragraph
        email.AddText("Email: " + Company.EMAIL + Environment.NewLine)
        email.Format.Font.Size = 7
        email.Format.Font.Italic = True
        headerRow.Cells(2).Add(companyName)
        headerRow.Cells(2).Add(physicalAddress)
        headerRow.Cells(2).Add(postCode)
        headerRow.Cells(2).Add(address)
        headerRow.Cells(2).Add(telephone)
        headerRow.Cells(2).Add(email)
        headerRow.Cells(2).Format.Alignment = ParagraphAlignment.Left
        headerTable.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        Dim tittleTable As Tables.Table = section.AddTable()
        tittleTable.Borders.Width = 0.25
        tittleTable.Borders.Left.Width = 0.5
        tittleTable.Borders.Right.Width = 0.5
        tittleTable.Rows.LeftIndent = 0
        Dim titleColumn As Tables.Column
        titleColumn = tittleTable.AddColumn("2.5cm")
        titleColumn.Format.Alignment = ParagraphAlignment.Left
        titleColumn = tittleTable.AddColumn("12.0cm")
        titleColumn.Format.Alignment = ParagraphAlignment.Left
        Dim titleRow As Tables.Row
        Dim documentTitle As New Paragraph
        documentTitle.AddText("Summarized Product Conversion Report")
        documentTitle.Format.Alignment = ParagraphAlignment.Left
        documentTitle.Format.Font.Size = 10
        documentTitle.Format.Font.Color = Colors.Black
        titleRow = tittleTable.AddRow()
        titleRow.Format.Font.Bold = True
        titleRow.HeadingFormat = True
        titleRow.Format.Font.Size = 8
        titleRow.Format.Alignment = ParagraphAlignment.Center
        titleRow.Format.Font.Bold = True
        titleRow.Borders.Color = Colors.White
        titleRow.Cells(0).AddParagraph("")
        titleRow.Cells(0).Format.Alignment = ParagraphAlignment.Left
        titleRow.Cells(1).Add(documentTitle)
        titleRow.Cells(1).Format.Alignment = ParagraphAlignment.Left
        tittleTable.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        'end of header

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("From: " + dateStart.Text + " to :" + dateEnd.Text)
        paragraph.Format.Font.Size = 8

        'Add the print date field
        paragraph = section.AddParagraph()
        paragraph.Format.SpaceBefore = "1cm"
        paragraph.Style = "Reference"
        paragraph.AddTab()
        paragraph.AddText("Created: ")
        paragraph.AddDateField("dd.MM.yyyy")

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Initial Products")
        paragraph.Format.Font.Size = 8

        Try
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

            column = table.AddColumn("2.5cm")
            column.Format.Alignment = ParagraphAlignment.Left

            column = table.AddColumn("1.5cm")
            column.Format.Alignment = ParagraphAlignment.Left

            column = table.AddColumn("6.0cm")
            column.Format.Alignment = ParagraphAlignment.Right

            column = table.AddColumn("1.0cm")
            column.Format.Alignment = ParagraphAlignment.Right

            column = table.AddColumn("2.0cm")
            column.Format.Alignment = ParagraphAlignment.Right

            column = table.AddColumn("2.5cm")
            column.Format.Alignment = ParagraphAlignment.Left

            'Create the header of the table
            Dim row As Tables.Row

            row = table.AddRow()
            row.Format.Font.Bold = True
            row.HeadingFormat = True
            row.Format.Font.Size = 8
            row.Format.Alignment = ParagraphAlignment.Center
            row.Format.Font.Bold = True
            row.Borders.Color = Colors.LightGray
            row.Cells(0).AddParagraph("Conversion Date")
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph("Item Code")
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph("Description")
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph("Qty")
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left
            row.Cells(4).AddParagraph("Price")
            row.Cells(4).Format.Alignment = ParagraphAlignment.Left
            row.Cells(5).AddParagraph("Amount")
            row.Cells(5).Format.Alignment = ParagraphAlignment.Left

            table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

            Dim totalAmount As Double = 0
            Dim totalVat As Double = 0
            Dim totalDiscount As Double = 0

            For i As Integer = 0 To dtgrdInitialProducts.RowCount - 1
                Dim claimDate As String = dtgrdInitialProducts.Item(0, i).Value.ToString
                Dim itemCode As String = dtgrdInitialProducts.Item(1, i).Value.ToString
                Dim description As String = dtgrdInitialProducts.Item(2, i).Value.ToString
                Dim qty As String = dtgrdInitialProducts.Item(3, i).Value.ToString
                Dim price As String = dtgrdInitialProducts.Item(4, i).Value.ToString
                Dim amount As String = dtgrdInitialProducts.Item(5, i).Value.ToString

                row = table.AddRow()
                row.Format.Font.Bold = False
                row.HeadingFormat = False
                row.Format.Font.Size = 8
                row.Height = "5mm"
                row.Format.Alignment = ParagraphAlignment.Center
                row.Borders.Color = Colors.LightGray
                row.Cells(0).AddParagraph(claimDate)
                row.Cells(0).Format.Alignment = ParagraphAlignment.Left
                row.Cells(1).AddParagraph(itemCode)
                row.Cells(1).Format.Alignment = ParagraphAlignment.Left
                row.Cells(2).AddParagraph(description)
                row.Cells(2).Format.Alignment = ParagraphAlignment.Left
                row.Cells(3).AddParagraph(qty)
                row.Cells(3).Format.Alignment = ParagraphAlignment.Left
                row.Cells(4).AddParagraph(price)
                row.Cells(4).Format.Alignment = ParagraphAlignment.Right
                row.Cells(5).AddParagraph(amount)
                row.Cells(5).Format.Alignment = ParagraphAlignment.Right

                table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
            Next
            table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Catch ex As Exception

        End Try

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Final Products")
        paragraph.Format.Font.Size = 8
        Try
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

            column = table.AddColumn("2.5cm")
            column.Format.Alignment = ParagraphAlignment.Left

            column = table.AddColumn("1.5cm")
            column.Format.Alignment = ParagraphAlignment.Left

            column = table.AddColumn("6.0cm")
            column.Format.Alignment = ParagraphAlignment.Right

            column = table.AddColumn("1.0cm")
            column.Format.Alignment = ParagraphAlignment.Right

            column = table.AddColumn("2.0cm")
            column.Format.Alignment = ParagraphAlignment.Right

            column = table.AddColumn("2.5cm")
            column.Format.Alignment = ParagraphAlignment.Left

            'Create the header of the table
            Dim row As Tables.Row

            row = table.AddRow()
            row.Format.Font.Bold = True
            row.HeadingFormat = True
            row.Format.Font.Size = 8
            row.Format.Alignment = ParagraphAlignment.Center
            row.Format.Font.Bold = True
            row.Borders.Color = Colors.LightGray
            row.Cells(0).AddParagraph("Conversion Date")
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph("Item Code")
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph("Description")
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph("Qty")
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left
            row.Cells(4).AddParagraph("Price")
            row.Cells(4).Format.Alignment = ParagraphAlignment.Left
            row.Cells(5).AddParagraph("Amount")
            row.Cells(5).Format.Alignment = ParagraphAlignment.Left

            table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

            Dim totalAmount As Double = 0
            Dim totalVat As Double = 0
            Dim totalDiscount As Double = 0

            For i As Integer = 0 To dtgrdFinalProducts.RowCount - 1
                Dim claimDate As String = dtgrdFinalProducts.Item(0, i).Value.ToString
                Dim itemCode As String = dtgrdFinalProducts.Item(1, i).Value.ToString
                Dim description As String = dtgrdFinalProducts.Item(2, i).Value.ToString
                Dim qty As String = dtgrdFinalProducts.Item(3, i).Value.ToString
                Dim price As String = dtgrdFinalProducts.Item(4, i).Value.ToString
                Dim amount As String = dtgrdFinalProducts.Item(5, i).Value.ToString

                row = table.AddRow()
                row.Format.Font.Bold = False
                row.HeadingFormat = False
                row.Format.Font.Size = 8
                row.Height = "5mm"
                row.Format.Alignment = ParagraphAlignment.Center
                row.Borders.Color = Colors.LightGray
                row.Cells(0).AddParagraph(claimDate)
                row.Cells(0).Format.Alignment = ParagraphAlignment.Left
                row.Cells(1).AddParagraph(itemCode)
                row.Cells(1).Format.Alignment = ParagraphAlignment.Left
                row.Cells(2).AddParagraph(description)
                row.Cells(2).Format.Alignment = ParagraphAlignment.Left
                row.Cells(3).AddParagraph(qty)
                row.Cells(3).Format.Alignment = ParagraphAlignment.Left
                row.Cells(4).AddParagraph(price)
                row.Cells(4).Format.Alignment = ParagraphAlignment.Right
                row.Cells(5).AddParagraph(amount)
                row.Cells(5).Format.Alignment = ParagraphAlignment.Right

                table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
            Next
            table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Cursor = Cursors.WaitCursor
        'load claimed items
        dtgrdInitialProducts.Rows.Clear()
        dtgrdFinalProducts.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT
                                        `items_to_convert`.`item_code` AS `item_code`,
                                        `item_conversion`.`date` AS `date`,
                                        SUM(`items_to_convert`.`qty`) AS `qty`
                                    FROM
                                        `items_to_convert`
                                    JOIN
                                        (SELECT * FROM `item_conversion` WHERE `date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' AND `status`='COMPLETED' OR `status`='ARCHIVED')`item_conversion`
                                    ON
                                        `item_conversion`.`id`=`items_to_convert`.`conversion_id`
                                    GROUP BY 
                                        `item_code`,`date`
                                    ORDER BY
                                        `date`
                                    "
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim total As Double = 0

            While reader.Read

                total = total + Val(reader.GetString("qty") * Val((New Item).getItemPrice(reader.GetString("item_code")).ToString))

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("date")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("item_code")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = (New Item).getItemLongDescription(reader.GetString("item_code"))
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("qty")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue((New Item).getItemPrice(reader.GetString("item_code")))
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue((Val(reader.GetString("qty") * Val((New Item).getItemPrice(reader.GetString("item_code")).ToString))))
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdInitialProducts.Rows.Add(dtgrdRow)
            End While

            conn.Close()

            Dim dtgrdRow1 As New DataGridViewRow
            Dim dtgrdCell1 As DataGridViewCell

            dtgrdCell1 = New DataGridViewTextBoxCell()
            dtgrdCell1.Value = ""
            dtgrdRow1.Cells.Add(dtgrdCell1)

            dtgrdCell1 = New DataGridViewTextBoxCell()
            dtgrdCell1.Value = ""
            dtgrdRow1.Cells.Add(dtgrdCell1)

            dtgrdCell1 = New DataGridViewTextBoxCell()
            dtgrdCell1.Value = ""
            dtgrdRow1.Cells.Add(dtgrdCell1)

            dtgrdCell1 = New DataGridViewTextBoxCell()
            dtgrdCell1.Value = ""
            dtgrdRow1.Cells.Add(dtgrdCell1)

            dtgrdCell1 = New DataGridViewTextBoxCell()
            dtgrdCell1.Value = "Total"
            dtgrdRow1.Cells.Add(dtgrdCell1)

            dtgrdCell1 = New DataGridViewTextBoxCell()
            dtgrdCell1.Value = LCurrency.displayValue(total)
            dtgrdRow1.Cells.Add(dtgrdCell1)

            dtgrdInitialProducts.Rows.Add(dtgrdRow1)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'load replacement items

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT
                                        `converted`.`item_code` AS `item_code`,
                                        `item_conversion`.`date` AS `date`,
                                        SUM(`converted`.`qty`) AS `qty`
                                    FROM
                                        `converted`
                                    JOIN
                                        (SELECT * FROM `item_conversion` WHERE `date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' AND `status`='COMPLETED' OR `status`='ARCHIVED')`item_conversion`
                                    ON
                                        `item_conversion`.`id`=`converted`.`conversion_id`
                                    GROUP BY 
                                        `item_code`,`date`
                                    ORDER BY
                                        `date`
                                    "

            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()



            Dim total As Double = 0

            While reader.Read

                total = total + Val(reader.GetString("qty") * Val((New Item).getItemPrice(reader.GetString("item_code")).ToString))

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("date")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("item_code")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = (New Item).getItemLongDescription(reader.GetString("item_code"))
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("qty")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue((New Item).getItemPrice(reader.GetString("item_code")))
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue((Val(reader.GetString("qty") * Val((New Item).getItemPrice(reader.GetString("item_code")).ToString))))
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdFinalProducts.Rows.Add(dtgrdRow)
            End While

            conn.Close()

            Dim dtgrdRow1 As New DataGridViewRow
            Dim dtgrdCell1 As DataGridViewCell

            dtgrdCell1 = New DataGridViewTextBoxCell()
            dtgrdCell1.Value = ""
            dtgrdRow1.Cells.Add(dtgrdCell1)

            dtgrdCell1 = New DataGridViewTextBoxCell()
            dtgrdCell1.Value = ""
            dtgrdRow1.Cells.Add(dtgrdCell1)

            dtgrdCell1 = New DataGridViewTextBoxCell()
            dtgrdCell1.Value = ""
            dtgrdRow1.Cells.Add(dtgrdCell1)

            dtgrdCell1 = New DataGridViewTextBoxCell()
            dtgrdCell1.Value = ""
            dtgrdRow1.Cells.Add(dtgrdCell1)

            dtgrdCell1 = New DataGridViewTextBoxCell()
            dtgrdCell1.Value = "Total"
            dtgrdRow1.Cells.Add(dtgrdCell1)

            dtgrdCell1 = New DataGridViewTextBoxCell()
            dtgrdCell1.Value = LCurrency.displayValue(total)
            dtgrdRow1.Cells.Add(dtgrdCell1)

            dtgrdFinalProducts.Rows.Add(dtgrdRow1)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        dtgrdInitialProducts.ClearSelection()
        dtgrdFinalProducts.ClearSelection()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnExportToPDF_Click(sender As Object, e As EventArgs) Handles btnExportToPDF.Click
        Cursor = Cursors.WaitCursor
        If dtgrdInitialProducts.RowCount = 0 And dtgrdFinalProducts.RowCount = 0 Then
            Cursor = Cursors.Default
            MsgBox("Nothing to print")
            Exit Sub
        End If

        Dim document As Document = New Document

        document.Info.Title = "Summarized Product Conversion Report"
        document.Info.Subject = "Summarized Product Conversion Report"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Summarized Product Conversion Report " & dateStart.Text & dateEnd.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)
        Cursor = Cursors.Default
    End Sub

    Private Sub frmProductConversionReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtgrdInitialProducts.Rows.Clear()
        dtgrdFinalProducts.Rows.Clear()
    End Sub
End Class