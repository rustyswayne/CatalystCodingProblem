/**
 * Created by rusty on 3/24/2017.
 */
// Dashboards
Peeps.Dashboards = {

    // initializes the component
    init: function() {
        Peeps.debugConsole('Dashboards initializing ...');

        var dashboards = $('div[data-dashboard]');
        if (dashboards.length) {
            _.each(dashboards, function(d) {
                Peeps.Dashboards.bind(d);
            });
        }

        Peeps.debugConsole('Dashboards initialized!')
    },

    bind: function(dashboard) {
        var id = Peeps.Dashboards.spinner.makeId();
        Peeps.Dashboards.spinner.appendSpinner(dashboard, id);

    },

    spinner: {

        activeIds: [],

        appendSpinner: function(dashboard, id) {

            Peeps.Dashboards.spinner.activeIds.push(id);

            var spinner = Peeps.Dashboards.spinner.build(id);

            $(dashboard).find(".chart-stage").html(spinner);
        },

        build: function(id) {

            return $('<div class="dashboard-spinner"><img src="' + Peeps.Settings.spinnerSvg + '" id="' + id + '" alt="Loading..." /></div>');
        },

        makeId: function() {
            var text = "",
                possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            for ( var i = 0; i < 10; i++ )
                text += possible.charAt(Math.floor(Math.random() * possible.length));

            return text;
        }

    }

};
