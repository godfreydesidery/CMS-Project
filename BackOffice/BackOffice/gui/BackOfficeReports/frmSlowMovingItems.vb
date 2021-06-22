Imports Devart.Data.MySql
Imports System.IO
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmSlowMovingItems


    Private Sub frmFastMovingItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub




    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub frmSupplySalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSupplier.Items.Clear()
        dtgrdList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            query = "SELECT`supplier_name` FROM `supplier` "
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                cmbSupplier.Items.Add(reader.GetString("supplier_name"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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
    Private Function print()


        Dim document As Document = New Document

        document.Info.Title = "Slow Moving Items Report"
        document.Info.Subject = "Slow Moving Items Report"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Slow Moving Items Report" & dateStart.Text & " to " & dateEnd.Text & " .pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)




        Return vbNull
    End Function
    Private Function printWithoutProfit()


        Dim document As Document = New Document

        document.Info.Title = "Slow Moving Items Report"
        document.Info.Subject = "Slow Moving Items Report"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocumentWithoutProfit(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Slow Moving Items Report" & dateStart.Text & " to " & dateEnd.Text & " .pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)

        Return vbNull
    End Function
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
        paragraph.AddFormattedText("Slow moving items", TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()
        paragraph.AddText("From:  " + dateStart.Text + "  To:  " + dateEnd.Text)
        paragraph.Format.Alignment = ParagraphAlignment.Left
        paragraph.Format.Font.Size = 8
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Vendor (" + (New Supplier).getSupplierCode("", cmbSupplier.Text) + ") " + cmbSupplier.Text)
        paragraph.Format.Alignment = ParagraphAlignment.Left
        paragraph.Format.Font.Size = 8
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("From:  " + dateStart.Text + "  To:  " + dateEnd.Text, TextFormat.Bold)
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

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("6.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("0.7cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("0.7cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.4cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'column = table.AddColumn("1.3cm")
        'column.Format.Alignment = ParagraphAlignment.Center


        column = table.AddColumn("2.1cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.3cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.HeadingFormat = True
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Format.Font.Size = 8
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Code")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Description")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Stk")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Qty")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("Price@")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        'row.Cells(5).AddParagraph("Disc")
        'row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph("VAT")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(6).AddParagraph("Amount")
        row.Cells(6).Format.Alignment = ParagraphAlignment.Left
        row.Cells(7).AddParagraph("Profit")
        row.Cells(7).Format.Alignment = ParagraphAlignment.Left

        table.SetEdge(0, 0, 8, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalQty As Double = 0

        For i As Integer = 0 To dtgrdList.RowCount - 1

            Dim code As String = dtgrdList.Item(0, i).Value
            Dim descr As String = dtgrdList.Item(1, i).Value
            Dim stock As String = dtgrdList.Item(2, i).Value
            Dim qty As String = dtgrdList.Item(3, i).Value
            Dim price As String = LCurrency.displayValue(dtgrdList.Item(4, i).Value)
            ' Dim discount As String = LCurrency.displayValue(dtgrdList.Item(5, i).Value)
            Dim vat As String = LCurrency.displayValue(dtgrdList.Item(6, i).Value)
            Dim amount As String = LCurrency.displayValue(dtgrdList.Item(7, i).Value)
            Dim profit As String = LCurrency.displayValue(dtgrdList.Item(8, i).Value)

            row = table.AddRow()
            row.Format.Font.Size = 6
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(code)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(descr)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(stock)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(qty)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left
            row.Cells(4).AddParagraph(price)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Right
            'row.Cells(5).AddParagraph(discount)
            'row.Cells(5).Format.Alignment = ParagraphAlignment.Right
            row.Cells(5).AddParagraph(vat)
            row.Cells(5).Format.Alignment = ParagraphAlignment.Right
            row.Cells(6).AddParagraph(amount)
            row.Cells(6).Format.Alignment = ParagraphAlignment.Right
            row.Cells(7).AddParagraph(profit)
            row.Cells(7).Format.Alignment = ParagraphAlignment.Right

            table.SetEdge(0, 0, 8, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Next

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Format.Font.Size = 8
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph()
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph()
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph()
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph()
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph()
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        'row.Cells(5).AddParagraph()
        'row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph()
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(6).AddParagraph()
        row.Cells(6).Format.Alignment = ParagraphAlignment.Left
        row.Cells(7).AddParagraph()
        row.Cells(7).Format.Alignment = ParagraphAlignment.Left
        row = table.AddRow()
        row.Format.Font.Bold = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Format.Font.Size = 8
        row.Borders.Color = Colors.White



        table.SetEdge(0, 0, 8, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        paragraph = section.AddParagraph()


        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("***End of Report***")
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9

    End Sub
    Private Sub createDocumentWithoutProfit(doc As Document)

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
        paragraph.AddFormattedText("Slow moving items", TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()
        paragraph.AddText("From:  " + dateStart.Text + "  To:  " + dateEnd.Text)
        paragraph.Format.Alignment = ParagraphAlignment.Left
        paragraph.Format.Font.Size = 8
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Vendor (" + (New Supplier).getSupplierCode("", cmbSupplier.Text) + ") " + cmbSupplier.Text)
        paragraph.Format.Alignment = ParagraphAlignment.Left
        paragraph.Format.Font.Size = 8
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("From:  " + dateStart.Text + "  To:  " + dateEnd.Text, TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Left
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green
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

        column = table.AddColumn("6.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("0.7cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("0.7cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.4cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'column = table.AddColumn("1.3cm")
        'column.Format.Alignment = ParagraphAlignment.Center


        column = table.AddColumn("2.1cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        ' column = table.AddColumn("2.3cm")
        ' column.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.HeadingFormat = True
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Format.Font.Size = 8
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Code")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Description")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Stk")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Qty")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("Price@")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        'row.Cells(5).AddParagraph("Disc")
        'row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph("VAT")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(6).AddParagraph("Amount")
        row.Cells(6).Format.Alignment = ParagraphAlignment.Left
        '  row.Cells(7).AddParagraph("Profit")
        ' row.Cells(7).Format.Alignment = ParagraphAlignment.Left

        table.SetEdge(0, 0, 7, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalQty As Double = 0

        For i As Integer = 0 To dtgrdList.RowCount - 1

            Dim code As String = dtgrdList.Item(0, i).Value
            Dim descr As String = dtgrdList.Item(1, i).Value
            Dim stock As String = dtgrdList.Item(2, i).Value
            Dim qty As String = dtgrdList.Item(3, i).Value
            Dim price As String = LCurrency.displayValue(dtgrdList.Item(4, i).Value)
            'Dim discount As String = LCurrency.displayValue(dtgrdList.Item(5, i).Value)
            Dim vat As String = LCurrency.displayValue(dtgrdList.Item(6, i).Value)
            Dim amount As String = LCurrency.displayValue(dtgrdList.Item(7, i).Value)
            '  Dim profit As String = LCurrency.displayValue(dtgrdList.Item(7, i).Value)

            row = table.AddRow()
            row.Format.Font.Size = 6
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(code)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(descr)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(stock)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(qty)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left
            row.Cells(4).AddParagraph(price)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Right
            'row.Cells(5).AddParagraph(discount)
            'row.Cells(5).Format.Alignment = ParagraphAlignment.Right
            row.Cells(5).AddParagraph(vat)
            row.Cells(5).Format.Alignment = ParagraphAlignment.Right
            row.Cells(6).AddParagraph(amount)
            row.Cells(6).Format.Alignment = ParagraphAlignment.Right
            '   row.Cells(7).AddParagraph(profit)
            '  row.Cells(7).Format.Alignment = ParagraphAlignment.Right

            table.SetEdge(0, 0, 7, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Next

        table.SetEdge(0, 0, 7, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        paragraph = section.AddParagraph()


        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("***End of Report***")
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9

    End Sub
    Private Function refreshList()
        dtgrdList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "SELECT `sale`.`date` as `date`,`sale_details`.`item_code` AS `item_code`,SUM(`sale_details`.`selling_price`-`sale_details`.`discounted_price`) AS `discount`,`sale_details`.`selling_price`AS `price`,SUM(`sale_details`.`qty`) AS `qty`,SUM(`sale_details`.`tax_return`) AS `tax`,SUM(`sale_details`.`amount`) AS `amount` FROM `sale`,`sale_details` WHERE `sale`.`id`=`sale_details`.`sale_id` AND `sale`.`date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' GROUP BY `item_code`,`date`,`price` ORDER BY `qty` ASC"

            If list <> "" Then
                query = "SELECT `sale`.`date` as `date`,`sale_details`.`item_code` AS `item_code`,SUM(`sale_details`.`selling_price`-`sale_details`.`discounted_price`) AS `discount`,`sale_details`.`selling_price`AS `price`,SUM(`sale_details`.`qty`) AS `qty`,SUM(`sale_details`.`tax_return`) AS `tax`,SUM(`sale_details`.`amount`) AS `amount` FROM `sale`,`sale_details` WHERE `sale`.`id`=`sale_details`.`sale_id` AND `sale`.`date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' AND `item_code` IN (" + list + ") GROUP BY `item_code`,`date`,`price` ORDER BY `qty` ASC"
            End If
            If cmbSupplier.Text <> "" Then
                ' query = "SELECT `items`.`supplier_id` AS `supplier_id`,`sale`.`date` as `date`,`sale_details`.`item_code` AS `item_code`,SUM(`sale_details`.`selling_price`-`sale_details`.`discounted_price`) AS `discount`,`sale_details`.`selling_price`AS `price`,SUM(`sale_details`.`qty`) AS `qty`,SUM(`sale_details`.`vat`) AS `vat`,SUM(`sale_details`.`amount`) AS `amount` FROM `sale`,`sale_details`,`items` WHERE `sale`.`id`=`sale_details`.`sale_id` AND `sale`.`date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' GROUP BY `item_code`,`date`,`price` ORDER BY `amount` DESC"
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim total As Double = 0
            Dim totalVat As Double = 0
            Dim totalDiscount As Double = 0
            Dim totalProfit As Double = 0

            While reader.Read
                Dim itemCode As String = reader.GetString("item_code")
                Dim description As String = (New Item).getItemLongDescription(itemCode)
                Dim stock As String = (New Item).getStock(itemCode)
                Dim qty As String = reader.GetString("qty")
                Dim price As String = reader.GetString("price")
                Dim discount As String = reader.GetString("discount")
                Dim tax As String = reader.GetString("tax")
                Dim amount As String = reader.GetString("amount")
                Dim item As New Item
                item.searchItem(itemCode)

                If cmbSupplier.Text <> "" Then
                    If cmbSupplier.Text <> (New Supplier).getSupplierName((New Item).getSupplierId("", "", itemCode), "") Then
                        Continue While
                    Else

                    End If
                End If

                Dim profit As String = (Val(amount) - (Val(qty) * Val(item.GL_COST_PRICE)) - Val(tax)).ToString
                totalProfit = totalProfit + Val(profit)

                total = total + Val(amount)
                totalDiscount = totalDiscount + Val(discount)
                totalVat = totalVat + Val(tax)

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = itemCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = description
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = stock
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = qty
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(price)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(discount)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(tax)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(amount)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(profit)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdList.Rows.Add(dtgrdRow)
            End While

            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function
    Dim list As String = ""

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        list = ""

        refreshList()

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        print()
    End Sub













    Private Sub cmbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSupplier.SelectedIndexChanged
    End Sub

    Private Sub btnPrintWithProfit_Click(sender As Object, e As EventArgs) Handles btnPrintWithProfit.Click
        printWithoutProfit()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub













    Private Sub dtgrdList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdList.CellContentClick

    End Sub
End Class