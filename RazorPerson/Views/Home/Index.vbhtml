@ModelType List(Of RazorPerson.Person)

<h2 class="text-primary">Liste des personnes</h2>
<p class="text-muted">@Model.Count personne(s) enregistrée(s)</p>

@Html.ActionLink("Ajouter une personne", "Create", "Home", Nothing, New With {.class = "btn btn-success"})

<table class="table table-striped table-bordered table-hover">
    <thead class="thead-dark">
        <tr>
            <th>Nom</th>
            <th>Âge</th>
            <th>Actions</th>
        </tr>
    </thead>
    <tbody>
        @For Each p In Model
@<tr>
    <td>@p.Name</td>
    <td>@p.Age</td>
    <td>
        @Html.ActionLink("Modifier", "Edit", New With {.id = p.Id}, New With {.class = "btn btn-warning btn-sm"})
        @Html.ActionLink("Supprimer", "Delete", New With {.id = p.Id}, New With {.class = "btn btn-danger btn-sm"})
    </td>
</tr>Next
    </tbody>
</table>