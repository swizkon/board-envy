
let BrowserUtil = window['BrowserUtil'] || {};

BrowserUtil.getQueryParameter = function(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

BrowserUtil.getJSON = function(url, callback) {
    $.getJSON(url, callback)
}

BrowserUtil.sendJSON = function(url, data, callback) {
    $.getJSON(url, callback)

    $.ajax({
        url: url,
        type: 'POST',
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        // async: false,
        success: callback
    });
}

export default BrowserUtil;