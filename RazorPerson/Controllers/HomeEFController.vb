Imports System.Data.Entity
Imports System.Web.Mvc

Public Class HomeEFController
    Inherits Controller

    Private ReadOnly _db As New RazorPersonContext()

    ' READ
    Public Function Index() As ActionResult
        Return View(_db.Personnes.ToList())
    End Function

    ' CREATE - affiche le formulaire
    Public Function Create() As ActionResult
        Return View()
    End Function

    ' CREATE - traite le formulaire
    <HttpPost>
    Public Function Create(p As Person) As ActionResult
        If ModelState.IsValid Then
            _db.Personnes.Add(p)
            _db.SaveChanges()
            Return RedirectToAction("Index")
        End If
        Return View(p)
    End Function
    ' EDIT - affiche le formulaire
    Public Function Edit(id As Integer) As ActionResult
        Return View(_db.Personnes.Find(id))
    End Function

    ' EDIT - traite le formulaire
    <HttpPost>
    Public Function Edit(p As Person) As ActionResult
        If ModelState.IsValid Then
            _db.Entry(p).State = EntityState.Modified
            _db.SaveChanges()
            Return RedirectToAction("Index")
        End If
        Return View(p)
    End Function

    ' DELETE - affiche la confirmation
    Public Function Delete(id As Integer) As ActionResult
        Return View(_db.Personnes.Find(id))
    End Function

    ' DELETE - effectue la suppression
    <HttpPost>
    <ActionName("Delete")>
    Public Function DeleteConfirmed(id As Integer) As ActionResult
        Dim p = _db.Personnes.Find(id)
        _db.Personnes.Remove(p)
        _db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

End Class