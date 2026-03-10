Imports System.Data.SqlClient
Imports System.Configuration

Public Class PersonRepository

    Private ReadOnly _connectionString As String

    Public Sub New()
        _connectionString = ConfigurationManager.ConnectionStrings("RazorPersonDB").ConnectionString
    End Sub

    ' READ - récupère toute la liste
    Public Function GetAll() As List(Of Person)
        Dim liste As New List(Of Person)
        Using conn As New SqlConnection(_connectionString)
            conn.Open()
            Dim cmd As New SqlCommand("SELECT Id, Name, Age, HtmlContent FROM Personne", conn)
            Dim reader = cmd.ExecuteReader()
            While reader.Read()
                liste.Add(New Person() With {
                    .Id = reader("Id"),
                    .Name = reader("Name"),
                    .Age = reader("Age"),
                    .HtmlContent = If(IsDBNull(reader("HtmlContent")), Nothing, reader("HtmlContent"))
                })
            End While
        End Using
        Return liste
    End Function

    ' READ - récupère une personne par Id
    Public Function GetById(id As Integer) As Person
        Dim p As Person = Nothing
        Using conn As New SqlConnection(_connectionString)
            conn.Open()
            Dim cmd As New SqlCommand("SELECT Id, Name, Age, HtmlContent FROM Personne WHERE Id = @Id", conn)
            cmd.Parameters.AddWithValue("@Id", id)
            Dim reader = cmd.ExecuteReader()
            If reader.Read() Then
                p = New Person() With {
                    .Id = reader("Id"),
                    .Name = reader("Name"),
                    .Age = reader("Age"),
                    .HtmlContent = If(IsDBNull(reader("HtmlContent")), Nothing, reader("HtmlContent"))
                }
            End If
        End Using
        Return p
    End Function

    ' CREATE
    Public Sub Insert(p As Person)
        Using conn As New SqlConnection(_connectionString)
            conn.Open()
            Dim cmd As New SqlCommand("INSERT INTO Personne (Name, Age, HtmlContent) VALUES (@Name, @Age, @HtmlContent)", conn)
            cmd.Parameters.AddWithValue("@Name", p.Name)
            cmd.Parameters.AddWithValue("@Age", p.Age)
            cmd.Parameters.AddWithValue("@HtmlContent", If(p.HtmlContent Is Nothing, DBNull.Value, p.HtmlContent))
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' UPDATE
    Public Sub Update(p As Person)
        Using conn As New SqlConnection(_connectionString)
            conn.Open()
            Dim cmd As New SqlCommand("UPDATE Personne SET Name = @Name, Age = @Age, HtmlContent = @HtmlContent WHERE Id = @Id", conn)
            cmd.Parameters.AddWithValue("@Name", p.Name)
            cmd.Parameters.AddWithValue("@Age", p.Age)
            cmd.Parameters.AddWithValue("@HtmlContent", If(p.HtmlContent Is Nothing, DBNull.Value, p.HtmlContent))
            cmd.Parameters.AddWithValue("@Id", p.Id)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' DELETE
    Public Sub Delete(id As Integer)
        Using conn As New SqlConnection(_connectionString)
            conn.Open()
            Dim cmd As New SqlCommand("DELETE FROM Personne WHERE Id = @Id", conn)
            cmd.Parameters.AddWithValue("@Id", id)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

End Class