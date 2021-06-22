Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Public Class frmProductionReport
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
        paragraph.AddFormattedText("Daily Production Report", TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("From: " + dateStart.Text + " to :" + dateEnd.Text)
        paragraph.Format.Font.Size = 8

        paragraph = section.AddParagraph()
        paragraph.AddText("N/B: Prices listed according to current selling prices")
        paragraph.Format.Font.Size = 7



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

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left


        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("6cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
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
        row.Cells(0).AddParagraph("Date")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Code")
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


        For i As Integer = 0 To dtgrdList.RowCount - 1
            Dim _date As String = dtgrdList.Item(0, i).Value.ToString
            Dim code As String = dtgrdList.Item(1, i).Value.ToString
            Dim description As String = dtgrdList.Item(2, i).Value.ToString
            Dim qty As String = dtgrdList.Item(3, i).Value.ToString
            Dim price As String = dtgrdList.Item(4, i).Value.ToString
            Dim amount As String = dtgrdList.Item(5, i).Value.ToString

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 8
            row.Height = "5mm"
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.LightGray
            row.Cells(0).AddParagraph(_date)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(code)
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

        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()

    End Sub


    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        generate()
    End Sub
    Private Sub generate()
        list = ""
        For i As Integer = 0 To lstCode.Items.Count - 1
            list = list + "'" + lstCode.Items.Item(i) + "'"
            If i < lstCode.Items.Count - 1 Then
                list = list + ","
            End If
        Next
        refreshList()
    End Sub
    Private Function refreshList()
        dtgrdList.Rows.Clear()

        Dim totalSales As Double = 0
        Dim totalVat As Double = 0
        Dim totalProfit As Double = 0
        Dim totalAmount As Double = 0

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            ' Dim categoryId As String = (New Material).getCategoryIdByCategoryName(cmbCategory.Text)

            query = "SELECT 
                        `item_code`,
                        `date`, 
                        SUM(`qty`) AS `qty`
                    FROM 
	                    `item_production`
                    WHERE
                        `date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "'
                    GROUP BY 
                        `item_code`,`date`
                    ORDER BY
                        `date`
                    "


            If list <> "" Then
                query = "SELECT 
                        `item_code`,
                        `date`, 
                        SUM(`qty`) AS `qty`
                    FROM 
	                    `item_production`
                    WHERE
                        `date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' AND `item_code` IN (" + list + ")
                    GROUP BY 
                        `item_code`,`date`
                    ORDER BY
                        `date`
                    "

            End If


            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim dtgrdRow As DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            While reader.Read
                Dim itemCode As String = reader.GetString("item_code")
                Dim _date As String = reader.GetString("date")
                Dim qty As String = reader.GetString("qty")

                'If categoryId <> "" And categoryId = (New Material).getMaterialCategoryId(materialCode) Then
                'ElseIf categoryId <> "" And categoryId <> (New Material).getMaterialCategoryId(materialCode) Then
                'Continue While
                ' End If

                Dim price As String = (New Item).getItemPrice(itemCode)
                totalAmount = totalAmount + (Val(qty) * Val(price))

                dtgrdRow = New DataGridViewRow

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = _date
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = itemCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = (New Item).getItemLongDescription(itemCode)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = qty
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(price)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue((Val(qty) * Val(price)).ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdList.Rows.Add(dtgrdRow)
            End While

            dtgrdRow = New DataGridViewRow

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = ""
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = ""
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = ""
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = ""
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = "Total"
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(totalAmount.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdList.Rows.Add(dtgrdRow)

            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Return vbNull
    End Function
    Dim list As String = ""

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    ' Private Sub loadCategories()
    ' Dim conn As New MySqlConnection(Database.conString)
    'Try
    'Dim suppcommand As New MySqlCommand()
    '   Dim supplierQuery As String = "SELECT
    '                                               `id`,
    '                                              `category_name`
    '                                         FROM
    '                                             `material_categories`"
    '         conn.Open()
    '         suppcommand.CommandText = supplierQuery
    '         suppcommand.Connection = conn
    '        suppcommand.CommandType = CommandType.Text
    ' Dim reader As MySqlDataReader = suppcommand.ExecuteReader
    '          cmbCategory.Items.Clear()
    '          cmbCategory.Items.Add("")
    '  If reader.HasRows Then
    '  While reader.Read
    '                   cmbCategory.Items.Add(reader.GetString("category_name"))
    '              End While
    '  End If
    '          conn.Close()
    '  Catch ex As Devart.Data.MySql.MySqlException
    '          ErrorMessage.dbConnectionError()
    '  Exit Sub
    '  End Try
    '  End Sub

    Private Sub frmSalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim item As New Item
        longList = item.getItems()
        '   loadCategories()
    End Sub
    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)
    Private Sub cmbDescription_KeyUp(sender As Object, e As EventArgs) Handles cmbMaterialName.KeyUp
        shortList.Clear()
        cmbMaterialName.Items.Clear()
        cmbMaterialName.DroppedDown = True
        For Each text As String In longList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbMaterialName.Text.ToUpper()) Then
                shortList.Add(text)
            End If
        Next
        cmbMaterialName.Items.AddRange(shortList.ToArray())
        cmbMaterialName.SelectionStart = cmbMaterialName.Text.Length
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnSearchItem_Click(sender As Object, e As EventArgs) Handles btnSearchItem.Click
        Dim found As Boolean = False
        Dim valid As Boolean = False
        Dim itemCode As String = txtMaterialCode.Text
        Dim descr As String = cmbMaterialName.Text

        If itemCode <> "" Then
            itemCode = itemCode
        ElseIf descr <> "" Then
            itemCode = (New Item).getItemCode(descr)
        Else
            itemCode = ""
        End If

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "SELECT
                                        `item_code`,
                                        `item_long_description`,
                                        `retail_price`
                                    FROM 
                                        `items`
                                    WHERE 
                                        `item_code`='" + itemCode + "' "
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtMaterialCode.Text = reader.GetString("item_code")
                cmbMaterialName.Text = reader.GetString("item_long_description")
                found = True
                valid = True
                Exit While
            End While
            conn.Close()
            If found = False Then
                MsgBox("Item not found")
                btnAdd.Enabled = False
            Else
                btnAdd.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        lstCode.Items.Add(txtMaterialCode.Text)
        clearFields()
        btnAdd.Enabled = False
    End Sub
    Private Sub clearFields()
        txtMaterialCode.Text = ""
        cmbMaterialName.Text = ""

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lstCode.Items.Clear()
        cmbCategory.Text = ""
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

        document.Info.Title = "Daily Production Report"
        document.Info.Subject = "Daily Production Report"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Daily Production Report " & dateStart.Text & dateEnd.Text & cmbCategory.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged

    End Sub
End Class