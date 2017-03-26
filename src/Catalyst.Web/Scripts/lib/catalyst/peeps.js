/**
 * Created by rusty on 3/24/2017.
 * scaffold based on https://github.com/rustyswayne/Merchello/blob/merchello-dev/src/Merchello.Mui.Client/src/jquery/mui/MUI.js
 *
 * REQUIRES:  underscore.js
 */
var Peeps = (function() {

    var DEBUG_MODE = {
        events: false,
        console: true
    };

    // Private members
    var eventHandlers = [];

    // Initialization
    function init() {
        $(document).ready(function() {
            // initialize the dashboards
            Peeps.Dashboards.init();

            // initialize GitHub feeds
            Peeps.GitHub.init();
        });
    }

    // indicates whether or not a JS logger is configured
    function hasLogger() {
        return false;
    }

    //// registers an event
    function registerEvent(evt, callback) {
        try
        {
            var existing = _.find(eventHandlers, function(ev) { return ev.event === evt; });
            if (existing !== undefined && existing !== null) {
                if (callback !== undefined && typeof callback === "function") {
                    existing.callbacks.push(callback);
                }
            } else {
                var callbacks = [];
                if (callback !== undefined && typeof callback === "function") {
                    callbacks.push(callback);
                }
                eventHandlers.push({ event: evt, callbacks: callbacks });
            }
        }
        catch (err) {
            console.info(err);
        }
    }

    /// emit the event
    function trigger(name, args) {
        var existing = _.find(eventHandlers, function(ev) { return ev.event === name; });
        if (existing === undefined || existing === null) return;

        // execute each of the registered callbacks
        _.each(existing.callbacks, function(cb) {
            try {
                cb(name, args);
            }
            catch(err) {
                MUI.Logger.captureError(err, {
                    extra: {
                        eventName: name,
                        args: args
                    }
                });
            }
        });
    }

    // create a generic cache of functions, where fn is the function to retrieve and execute for a value.
    // also ensures, the function is executed once and a single value is returned.
    function createCache(fn) {
        var cache = {};
        return function( key, callback ) {
            if ( !cache[ key ] ) {
                cache[ key ] = $.Deferred(function( defer ) {
                    fn( defer, key );
                }).promise();
            }
            return cache[ key ].done( callback );
        };
    }

    // utility method to map the event name from an alias so they can be
    // more easily referenced in other modules
    function getEventNameByAlias(events, alias) {
        var evt = _.find(events, function(e) { return e.alias === alias});
        return evt === undefined ? '' : evt.name;
    }

    // writes events to debug console
    function debugConsoleEvents(events) {
        if (DEBUG_MODE.events) {
            _.each(events, function(ev) {
                MUI.on(ev.name, function(name, args) {
                    console.log(ev);
                    console.log(args === undefined ? 'No args' : args);
                });
            });
        }
    }

    // write to debug console if in debug mode
    function debugConsole(obj) {
        if (DEBUG_MODE.console) {
            console.log(obj);
        }
    }

    //
    function willWork(selector) {
        return $(selector).length > 0;
    }

    // exposed members
    return {
        // ensures the settings object is created
        Settings: {
            Notifications: {},
            Endpoints: {}
        },
        // ensures the services object is created
        init: init,
        willWork: willWork,
        hasLogger: hasLogger,
        createCache: createCache,
        on: registerEvent,
        emit: trigger,
        getEventNameByAlias: getEventNameByAlias,
        debugConsoleEvents : debugConsoleEvents,
        debugConsole: debugConsole
    }

})();

/**
 * Created by rusty on 3/24/2017.
 */
// Settings for Peeps
Peeps.Settings = {

    localCacheDuration: 10, // 10 minutes

    // path to the spinner svg file
    spinnerSvg: '/Media/Placeholders/balls.svg',

    // flag for demoing api delays
    enableApiDelays: true,

    apiRoutes: [
     // { id: "route alias", value: "use this for the $.ajax url", title: "message to replace 'Intializing...'", notes: "notes replacement",  delay: NOT REQUIRE (FOR DEMO) }
        { id: 'countrymetrics', value: '/dashboard/countriessnapshot', title: "Querying Country Metrics...", notes: 'Country filter queries not implemented.', delay: 750 },
        { id: 'peopleprops', value: '/dashboard/peoplepropertystats', title: "Evaluating Profiles...", notes: 'Property filter queries not implemented.', delay: 1250 },
        { id: 'randomwatched', value: '/dashboard/randomwatched', title: "Selecting random...", notes: 'Randomly selected from watched', delay: 0 }
    ]

}
/**
 * Created by rusty on 3/24/2017.
 */
// Dashboards
// REQUIRES:  underscore.js
Peeps.Dashboards = {

    // initializes the component
    init: function() {

        var dashboards = $('div[data-dashboard]');
        if (dashboards.length) {
            _.each(dashboards, function(d) {
                // invoke the binder
                Peeps.Dashboards.binder.invoke(d);
            });
        }
    },

    // method to bind individual dashboard item
    binder: {

        // invokes the initialization of the dashboard component
        invoke: function(dashboard) {

            // if the alias from the data value is 'donothing' skip making the ajax call (but log).
            const skipflag = 'donothing';

            var routeAlias = $(dashboard).data('dashboard');

            // Append the ajax spinner to the dashboard item content
            // todo remove this entire "id" concept.  turns out not need
            var id = Peeps.Dashboards.spinner.makeId();
            Peeps.Dashboards.spinner.appendSpinner(dashboard, id);

            var dashParams = {
                dashboard: dashboard,
                args: {},
                skip: true
            };

            // Lookup what controller action needs to be called
            // IF skipflag - leave spinner spinning
            if (routeAlias === skipflag) {
                return; // bail
            }

            // find the route record (hard code in Peeps.Settings)
            var route = _.find(Peeps.Settings.apiRoutes, function (r) {
                if (r.id === routeAlias) {
                    return r;
                }
            });

            // update the dash params
            if (route !== undefined) {
                dashParams.args = route;
                dashParams.skip = false;
                Peeps.Dashboards.binder.query(dashParams);
            }
        },

        // query the controller for the partial view content
        query: function(params) {
            if (params === undefined) throw new Error('Routing params have not been defined.');

            var panel = params.dashboard;
            $(panel).find('.chart-title').text(params.args.title);

            // adding a note here for the demo
            // the load is pretty quick and you can't really see the ajax loader if running locally
            // update the note
            var delay = params.args.delay === undefined ? 0 : params.args.delay;
            if (!Peeps.Settings.enableApiDelays) delay = 0;

            if (delay > 0) {
                $(panel).find('.chart-notes').text('FAKE DELAY of (' + params.args.delay + ' ms) added for demo!');
            }

            $(panel).find('');
            // replace the dashboard
            $.ajax({
                url: params.args.value,
                dataType: "html"
            }).done(function(data) {

                setTimeout(function(){
                    $(panel).parent().html(data);
                    $(panel).find('.chart-notes').text('Note:');
                    }, delay);

            }).fail(function() {
                console.log('Failure not implemented.');
            });
        }

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

Peeps.Storage = {
    Cache: {
        setItem: function(key, value) {
            var now = new Date();
            value.peeps = {};
            value.peeps.cacheStamp = now;
            value.peeps.expired = false;

            if (localStorage) {
                localStorage.setItem('__peeps-' + key, JSON.stringify(value));
            }
        },

        getItem: function(key) {
            var now = new Date();
            if (localStorage) {
                var value = JSON.parse(localStorage.getItem('__peeps-' + key));
                if (!value) {
                    return null;
                }
                var cachedDate = new Date(value.peeps.cacheStamp);
                var diffMs = now - cachedDate;
                var diffMins = Math.round(((diffMs % 86400000) % 3600000) / 60000);
                if (diffMins > Peeps.Settings.localCacheDuration) {
                    value.peeps.expired = true;
                } else {
                    return value;
                }
            }
        }
    }
}

// GitHub feeds
Peeps.GitHub = {
    feedCount: 20,
    init: function() {
        if (Peeps.willWork('.github-activity')) {
            Peeps.GitHub.getCommitFeeds();
        }
    },
    getCommitFeeds: function() {
        $('.github-activity').each(function() {
            var owner = $(this).attr('data-owner');
            var repo = $(this).attr('data-repo');
            var storageKey = owner + '-' + repo;
            Peeps.GitHub.getFeed($(this), UD.GitHub.getCommitApiUrl(owner, repo), storageKey);
        });
    },
    getFeed: function (parent, url, storageKey) {
        var cached = Peeps.Storage.Cache.getItem(storageKey);
        if (cached == null || cached.expired == true) {
            $.ajax({
                url: url,
                dataType: 'jsonp',
                success: function (results) {
                    if (results != null) {
                        Peeps.Storage.Cache.setItem(storageKey, results);
                        Peeps.GitHub.generateList(parent, results);
                    } else {
                        // failed call - try to use the expired results if I have them
                        if (cached != null) {
                            Peeps.debugConsole('using expired.');
                            Peeps.GitHub.generateList(parent, cached);
                        }
                    }
                }
            });
        } else {
            Peeps.GitHub.generateList(parent, cached);
        }
    },
    createAvatar: function(src) {
        var img = document.createElement('img');
        $(img).attr('src', src).addClass('avatar');
        return img;
    },
    createSpan: function(txt, css) {
        var span = document.createElement('span');
        $(span).addClass(css).text(txt);
        return span;
    },
    createAnchor: function(url, txt, css) {
        var a = document.createElement('a');
        $(a).attr('href', url).addClass(css).text(txt);
        return a;
    },
    getCommitApiUrl: function (owner, repo) {
        return 'https://api.github.com/repos/' + owner + '/' + repo + '/commits?callback=?';
    },
    generateList: function(parent, results) {
        if (results.data.length > 0) {
            // get the commits
            var ul = document.createElement('ul');

            $.each(results.data.slice(0, UD.GitHub.feedCount), function (key, value) {
                var li = document.createElement('li'); //.css('commit')

                var avatar = '';
                if (value.author !== null) {
                    avatar = value.author.avatar_url;
                    $(li).append(Peeps.GitHub.createAvatar(avatar));
                }

                var div = document.createElement('div');
                $(div).addClass('commit');

                if (value.author !== null) {
                    $(div).append(Peeps.GitHub.createAnchor(value.author.html_url, value.author.login, 'author'));
                }

                var icon = document.createElement('i');
                $(icon).addClass('octicon').addClass('octicon-git-commit');
                $(div).append(icon);
                console.info(value);
                if (value.parents !== null) {
                    $(div).append(Peeps.GitHub.createAnchor(value.parents[0].html_url, value.commit.message, 'message'));
                } else {
                    $(div).append(Peeps.GitHub.createSpan(value.commit.message, 'message'));
                }

                $(li).append(div);
                //var date = new Date(value.commit.committer.date);
                // $(li).append(UD.GitHub.createSpan(date.toLocaleDateString(), 'date'));
                $(ul).append(li);

            });
            $(parent).append(ul);
            $(parent).children('.loading').removeClass('expanded');
        }
    }
}
//// Bootstrap Peeps!
Peeps.init();
