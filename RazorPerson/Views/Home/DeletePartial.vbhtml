@ModelType RazorPerson.Person
<h2 class="text-primary">Supprimer une personne (Partial)</h2>

<p>Êtes-vous sûr de vouloir supprimer <strong>@Model.Name</strong> ?</p>

@Using Html.BeginForm("DeletePartial", "Home", FormMethod.Post)
@Html.HiddenFor(Function(m) m.Id)
               @<button type="submit" class="btn btn-danger">Supprimer</button>
                                @Html.ActionLink("Annuler", "IndexPartial", Nothing, New With {.class = "btn btn-default"})End Using