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

    searchApiEndpoint: '/api/searchapi/getall/',

    newPerson: '/people/newperson/',

    apiRoutes: [
     // { id: "route alias", value: "use this for the $.ajax url", title: "message to replace 'Intializing...'", notes: "notes replacement",  delay: NOT REQUIRE (FOR DEMO) }
        { id: 'countrymetrics', value: '/dashboard/countriessnapshot', title: "Querying Country Metrics...", notes: 'Country filter queries not implemented.', delay: 750 },
        { id: 'peopleprops', value: '/dashboard/peoplepropertystats', title: "Evaluating Profiles...", notes: 'Property filter queries not implemented.', delay: 1250 },
        { id: 'randomwatched', value: '/dashboard/randomwatched', title: "Selecting random...", notes: 'Randomly selected from watched', delay: 0 }
    ]

}