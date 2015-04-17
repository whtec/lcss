String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, ""); //(/(^\s*)|(\s*$)/g, "");
}
var request = {
    QueryString: function (val) {
        var uri = unescape(window.location.search);
        var re = new RegExp("" + val + "=([^&?]*)", "ig");
        return ((uri.match(re)) ? (uri.match(re)[0].substr(val.length + 1)) : null);
    }
};