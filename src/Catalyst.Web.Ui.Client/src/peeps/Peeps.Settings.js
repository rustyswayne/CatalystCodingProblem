/**
 * Created by rusty on 3/24/2017.
 */
// Settings for Peeps
Peeps.Settings = {

    // path to the spinner svg file
    spinnerSvg: '/Media/Placeholders/balls.svg',

    // flag for demoing api delays
    enableApiDelays: true,

    apiRoutes: [
     // { id: "route alias", value: "use this for the $.ajax url", title: "message to replace 'Intializing...'", delay: NOT REQUIRE (FOR DEMO) }
        { id: 'countrymetrics', value: '/dashboard/countriessnapshot', title: "Querying Country Metrics...", delay: 750 },
        { id: 'peopleprops', value: '/dashboard/peoplepropertystats', title: "Evaluating Profiles...", delay: 1250 },
        { id: 'randomtweet', value: '/dashboard/randomlasttweet', title: "Checking Twitter...", delay: 0 }
    ]

}