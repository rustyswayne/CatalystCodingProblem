Peeps.Dialogs = {

    confirmDelete: function(confirm, cancel) {
        Peeps.Dialogs.confirm({
            title: 'Delete this person?',
            message: 'This person will be permanently deleted and cannot be recovered. Are you sure?',
            confirm: confirm,
            cancel: cancel
        });
    },

    confirm: function(args) {

        // args { title: '', message: '', confirm: callback, cancel: callback}

        var template = $('<div id="dialog-confirm" title="' + args.title + '">' +
            '<p><span class="ui-icon ui-icon-alert" style="float:left; margin:12px 12px 20px 0;"></span>' + args.message + '</p>' +
            '</div>')

        $('#peeps').html(template);

        $('#dialog-confirm').dialog({
            resizable: false,
            height: "auto",
            width: 400,
            modal: true,
            buttons: {
                "Confirm": function () {
                    if (args.confirm !== undefined) args.confirm();
                    $(this).dialog("close");
                },
                Cancel: function () {
                    if (args.cancel !== undefined) args.cancel();
                    $(this).dialog("close");
                }
            }
        });
    }

}
