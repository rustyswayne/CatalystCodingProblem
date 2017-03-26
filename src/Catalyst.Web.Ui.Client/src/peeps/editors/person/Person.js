Peeps.Editors.Person = {

    init: function() {

        // have to wait to bind the form since they are loaded async
        Peeps.on(Peeps.Dashboards.loadedEvtName, Peeps.Editors.Person.onDashboardLoaded);

        // always do this
        Peeps.Editors.Person.bind.deletes();

    },

    onDashboardLoaded: function(s, e) {

      if (e.params.id === 'addperson') {
          Peeps.Editors.Person.bind.personEntry(e);
      }

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

        personEntry: function(args) {

            console.info(args);
            if (!Peeps.willWork('#person-entry')) return;


            var frm = $('#person-entry');

            // rebind the unobtrusive validation
            Peeps.Forms.rebind(frm);

            $(frm).find('#Birthday').datepicker({
                changeYear: true,
                yearRange: "1930:2017"
            });
        }

    }
}
