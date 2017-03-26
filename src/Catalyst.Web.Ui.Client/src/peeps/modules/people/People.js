Peeps.People = {

    init: function() {
        // always do this
        Peeps.People.bind.deletes();
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
        }
    }
}
