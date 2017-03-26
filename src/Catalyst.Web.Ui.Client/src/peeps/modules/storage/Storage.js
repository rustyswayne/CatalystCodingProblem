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
