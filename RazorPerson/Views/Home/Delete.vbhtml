@ModelType RazorPerson.Person

<h2 class="text-danger">Supprimer une personne</h2>

<p class="text-muted">Êtes-vous sûr de vouloir supprimer cette personne ?</p>

<div class="well">
    <p><strong>Nom :</strong> @Model.Name</p>
    <p><strong>Âge :</strong> @Model.Age ans</p>
</div>

@Using Html.BeginForm()
@Html.HiddenFor(Function(m) m.Id)
               @<button type="submit" class="btn btn-danger">Confirmer la suppression</button>
                                @Html.ActionLink("Annuler", "Index", Nothing, New With {.class = "btn btn-default"})
End Using