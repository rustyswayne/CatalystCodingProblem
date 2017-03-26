Peeps.People = {

    init: function() {
        // always do this
        Peeps.People.bind.deletes();

        Peeps.People.bind.newPerson();

    },
    bind: {
        deletes: function() {
            if (Peeps.willWork('.delete-person')) {
            _.each($('.delete-person'), function(el) {

                $(el).bind('click', function(e) {
                    e.preventDefault();
                    var targetUrl = $(this).attr("href");
                    Peeps.Dialogs.confirmDelete(function() {

                       window.location = targetUrl;
                    });
                });

            });
            }
        },

        newPerson: function() {
            if (Peeps.willWork('#new-person')) {
                // bind the new person button
                $('#new-person').bind('click', function(e) {

                    $.get(Peeps.Settings.newPerson).done(function(frm) {

                        var dialog = Peeps.Dialogs.popForm({ frm: frm });
                        dialog.dialog('open');

                        // rebind the validation
                        Peeps.Forms.rebind(dialog);

                        $(dialog).find('.cancel').bind('click', function(e) {
                           dialog.dialog('close');
                        });
                        // wire up the date box
                        $(dialog).find('#birthday-picker').birthdayPicker({
                            minAge: 16
                        });

                        $(dialog).find('form').bind('submit', function(e) {
                           $(this).find('#Birthday').val($(this).find('.birthDay').val());

                        });
                    });

                });
            }
        }
    }
}
