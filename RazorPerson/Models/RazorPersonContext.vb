Imports System.Data.Entity

Public Class RazorPersonContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=RazorPersonDB")
    End Sub

    Public Property Personnes As DbSet(Of Person)

End Class