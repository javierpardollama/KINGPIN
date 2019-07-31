"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var rxjs_1 = require("rxjs");
var time_app_variants_1 = require("./../variants/time.app.variants");
var text_app_variants_1 = require("./../variants/text.app.variants");
var BaseService = /** @class */ (function () {
    function BaseService(httpClient, matSnackBar) {
        this.httpClient = httpClient;
        this.matSnackBar = matSnackBar;
    }
    BaseService.prototype.HandleError = function (operation, result) {
        var _this = this;
        if (operation === void 0) { operation = 'Operation'; }
        return function (response) {
            var expception = {
                Message: response.error.Message,
                StatusCode: response.error.StatusCode
            };
            _this.matSnackBar.open(expception.Message, text_app_variants_1.TextAppVariants.AppOkButtonText, { duration: time_app_variants_1.TimeAppVariants.AppToastSecondTicks * time_app_variants_1.TimeAppVariants.AppTimeSecondTicks });
            // Let the app keep running by returning an empty result.
            return rxjs_1.of(result);
        };
    };
    return BaseService;
}());
exports.BaseService = BaseService;
//# sourceMappingURL=base.service.module.js.map