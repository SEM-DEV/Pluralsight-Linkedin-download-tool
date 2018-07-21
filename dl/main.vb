Imports System.IO
Public Class main
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyData = Keys.Return Then
            TextBox2.Focus()
        End If
    End Sub
    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyData = Keys.Return Then
            TextBox3.Focus()
        End If
    End Sub
    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyData = Keys.Return Then
            TextBox6.Focus()
        End If
    End Sub
    Private Sub textbox4_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyData = Keys.Return Then
            Button1.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Const quote As String = """"
        Label1.Text = "youtube-dl --username " & quote & TextBox1.Text & quote & " --password " & quote & TextBox2.Text & quote & " --verbose --sleep-interval " & TextBox3.Text & " " & "--rate-limit " & TextBox6.Text & "k" & " " & quote & TextBox4.Text & quote
        Clipboard.SetText(Label1.Text)
        Shell("CMD.exe")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Add(TextBox5.Text)
        ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
        ''If TextBox5.Text = "" Then
        ''    MessageBox.Show("Please put the link or paste it")
        ''Else
        ''    ListBox1.Items.Add(TextBox5.Text)
        ''End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListBox1.Items.Remove(ListBox1.SelectedItem)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        TextBox4.Text = ListBox1.SelectedItem
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox5.Text = Clipboard.GetText()
        Button2.Focus()
        ListBox1.Items.Add(TextBox5.Text)
        ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        IO.Directory.CreateDirectory("C:\Test")
        Dim w As New IO.StreamWriter("C:\Test\test.txt")
        Dim i As Integer
        For i = 0 To ListBox1.Items.Count - 1
            w.WriteLine(ListBox1.Items.Item(i))
        Next
        w.Close()
    End Sub

    Dim myx As Integer
    Dim myy As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim r As New IO.StreamReader("C:\Test\test.txt")
        While (r.Peek() > -1)
            ListBox1.Items.Add(r.ReadLine)
        End While
        r.Close()
        TextBox1.Text = My.Settings.Mytext
        TextBox3.Text = My.Settings.container1
        TextBox6.Text = My.Settings.container2
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        IO.Directory.CreateDirectory("C:\Test")
        Dim w As New IO.StreamWriter("C:\Test\test.txt")
        Dim i As Integer
        For i = 0 To ListBox1.Items.Count - 1
            w.WriteLine(ListBox1.Items.Item(i))
        Next
        w.Close()
        My.Settings.Mytext = TextBox1.Text
        My.Settings.container1 = TextBox3.Text
        My.Settings.container2 = TextBox6.Text
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
