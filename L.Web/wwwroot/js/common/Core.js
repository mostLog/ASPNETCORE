var core = core || {};
core.services = core.services || {};
core.util = core.util || {};
/*
 *创建服务
*/
core.util.createService = function (serviceName) {
    var service = core.services[serviceName];
    if (service == undefined) {
        core.services[serviceName] = {};
    } else {
        return service;
    }
    return core.services[serviceName];
};