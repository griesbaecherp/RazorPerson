<h2 class="text-primary">Liste des personnes (AjaxToast)</h2>

<button id="btnCharger" class="btn btn-primary">Charger les personnes</button>
<button class="btn btn-success" data-toggle="modal" data-target="#modalCreate">Ajouter</button>

<!-- Toast simulé -->
<div id="toast" style="display:none; position:fixed; top:20px; right:20px; z-index:9999; min-width:250px; padding:15px 20px; border-radius:5px; color:#fff; box-shadow: 0 4px 12px rgba(0,0,0,0.3);">
    <span id="toastMessage"></span>
</div>

<!-- Modal Create -->
<div class="modal fade" id="modalCreate">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Ajouter une personne</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <label>Nom</label>
                    <input type="text" id="createName" class="form-control" />
                    <span class="text-danger" id="errCreateName"></span>
                </div>
                <div class="form-group">
                    <label>Âge</label>
                    <input type="number" id="createAge" class="form-control" />
                    <span class="text-danger" id="errCreateAge"></span>
                </div>
            </div>
            <div class="modal-footer">
                <button id="btnSauvegarder" class="btn btn-success">Sauvegarder</button>
                <button class="btn btn-default" data-dismiss="modal">Annuler</button>
            </div>
        </div>
    </div>
</div>

<!-- Modal Edit -->
<div class="modal fade" id="modalEdit">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Modifier une personne</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body">
                <input type="hidden" id="editId" />
                <div class="form-group">
                    <label>Nom</label>
                    <input type="text" id="editName" class="form-control" />
                    <span class="text-danger" id="errEditName"></span>
                </div>
                <div class="form-group">
                    <label>Âge</label>
                    <input type="number" id="editAge" class="form-control" />
                    <span class="text-danger" id="errEditAge"></span>
                </div>
            </div>
            <div class="modal-footer">
                <button id="btnModifierSauvegarder" class="btn btn-warning">Sauvegarder</button>
                <button class="btn btn-default" data-dismiss="modal">Annuler</button>
            </div>
        </div>
    </div>
</div>

<!-- Modal Delete confirmation -->
<div class="modal fade" id="modalDelete">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Confirmer la suppression</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body">
                <p>Êtes-vous sûr de vouloir supprimer <strong id="deleteNom"></strong> ?</p>
                <input type="hidden" id="deleteId" />
            </div>
            <div class="modal-footer">
                <button id="btnConfirmerSupprimer" class="btn btn-danger">Supprimer</button>
                <button class="btn btn-default" data-dismiss="modal">Annuler</button>
            </div>
        </div>
    </div>
</div>

<table class="table table-striped table-bordered table-hover" style="margin-top:20px">
    <thead class="thead-dark">
        <tr>
            <th>Nom</th>
            <th>Âge</th>
            <th>Actions</th>
        </tr>
    </thead>
    <tbody id="tbodyPersonnes">
    </tbody>
</table>

@Section scripts
    <script>// Fonction toast simulé
        function afficherToast(message, couleur) {
            $("#toastMessage").text(message);
            $("#toast").css("background-color", couleur).stop(true).fadeIn(300);
            setTimeout(function () {
                $("#toast").fadeOut(500);
            }, 3000);
        }

        // Fonction de validation réutilisable
        function validerPersonne(nomId, ageId, errNomId, errAgeId) {
            var valide = true;
            var nom = $("#" + nomId).val().trim();
            var age = $("#" + ageId).val();

            $("#" + errNomId).text("");
            $("#" + errAgeId).text("");

            if (nom === "") {
                $("#" + errNomId).text("Le nom est obligatoire.");
                valide = false;
            } else if (nom.length < 2) {
                $("#" + errNomId).text("Le nom doit avoir au moins 2 caractères.");
                valide = false;
            }

            if (age === "" || age === null) {
                $("#" + errAgeId).text("L'âge est obligatoire.");
                valide = false;
            } else if (age < 0 || age > 120) {
                $("#" + errAgeId).text("L'âge doit être entre 0 et 120.");
                valide = false;
            }

            return valide;
        }

        $("#btnCharger").click(function () {
            $.ajax({
                url: "/Home/GetPersonnes",
                type: "GET",
                success: function (data) {
                    var html = "";
                    $.each(data, function (i, p) {
                        html += "<tr>";
                        html += "<td>" + p.Name + "</td>";
                        html += "<td>" + p.Age + "</td>";
                        html += "<td>";
                        html += "<button class='btn btn-warning btn-sm btnModifier' data-id='" + p.Id + "' data-name='" + p.Name + "' data-age='" + p.Age + "'>Modifier</button> ";
                        html += "<button class='btn btn-danger btn-sm btnSupprimer' data-id='" + p.Id + "' data-name='" + p.Name + "'>Supprimer</button>";
                        html += "</td>";
                        html += "</tr>";
                    });
                    $("#tbodyPersonnes").html(html);
                }
            }).fail(function () {
                afficherToast("Une erreur est survenue.", "#d9534f");
            });
        });

        $(document).on("click", ".btnSupprimer", function () {
            $("#deleteId").val($(this).data("id"));
            $("#deleteNom").text($(this).data("name"));
            $("#modalDelete").modal("show");
        });

        $("#btnConfirmerSupprimer").click(function () {
            var id = $("#deleteId").val();
            var nom = $("#deleteNom").text();
            $.ajax({
                url: "/Home/DeleteAjax",
                type: "POST",
                data: { id: id },
                success: function (data) {
                    if (data.success) {
                        $("#modalDelete").modal("hide");
                        $("#btnCharger").click();
                        afficherToast(nom + " a été supprimé.", "#d9534f");
                    }
                }
            }).fail(function () {
                afficherToast("Une erreur est survenue.", "#d9534f");
            });
        });

        $(document).on("click", ".btnModifier", function () {
            $("#editId").val($(this).data("id"));
            $("#editName").val($(this).data("name"));
            $("#editAge").val($(this).data("age"));
            $("#errEditName").text("");
            $("#errEditAge").text("");
            $("#modalEdit").modal("show");
        });

        $("#btnModifierSauvegarder").click(function () {
            if (!validerPersonne("editName", "editAge", "errEditName", "errEditAge")) return;
            $.ajax({
                url: "/Home/EditAjax",
                type: "POST",
                data: {
                    Id: $("#editId").val(),
                    Name: $("#editName").val(),
                    Age: $("#editAge").val()
                },
                success: function (data) {
                    if (data.success) {
                        $("#modalEdit").modal("hide");
                        $("#btnCharger").click();
                        afficherToast($("#editName").val() + " a été modifié.", "#f0ad4e");
                    }
                }
            }).fail(function () {
                afficherToast("Une erreur est survenue.", "#d9534f");
            });
        });

        $("#btnSauvegarder").click(function () {
            if (!validerPersonne("createName", "createAge", "errCreateName", "errCreateAge")) return;
            $.ajax({
                url: "/Home/CreateAjax",
                type: "POST",
                data: {
                    Name: $("#createName").val(),
                    Age: $("#createAge").val()
                },
                success: function (data) {
                    if (data.success) {
                        $("#modalCreate").modal("hide");
                        $("#btnCharger").click();
                        afficherToast($("#createName").val() + " a été ajouté.", "#5cb85c");
                    }
                }
            }).fail(function () {
                afficherToast("Une erreur est survenue.", "#d9534f");
            });
        });

        $("#modalCreate").on("show.bs.modal", function () {
            $("#createName").val("");
            $("#createAge").val("");
            $("#errCreateName").text("");
            $("#errCreateAge").text("");
        });</script>
End Section