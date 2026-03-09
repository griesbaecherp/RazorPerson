@ModelType IEnumerable(Of RazorPerson.Person)
<h2 class="text-primary">Liste des personnes (Partial)</h2>

@Html.ActionLink("Ajouter", "CreatePartial", Nothing, New With {.class = "btn btn-success"})

<table class="table table-striped table-bordered table-hover" style="margin-top:20px">
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
        @Html.ActionLink("Modifier", "EditPartial", New With {.id = p.Id}, New With {.class = "btn btn-warning btn-sm"})
        @Html.ActionLink("Supprimer", "DeletePartial", New With {.id = p.Id}, New With {.class = "btn btn-danger btn-sm"})
    </td>
</tr>Next
    </tbody>
</table>