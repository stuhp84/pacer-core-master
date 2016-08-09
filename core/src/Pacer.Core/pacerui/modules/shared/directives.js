angular
.module('Shared')
.directive('billing', function() {
    return {
        templateUrl: 'modules/shared/views/receipt.html'
    };
})
    .directive ('dateBefore',
        function(){
            return {
                require: 'ngModel',
                    link: function (scope, el, attrs, ctrl) {
                    var isInclusive = attrs.dateOrEquals ? scope.$eval(attrs.dateOrEquals) : false,
                        validate = function (val1, val2) {
                            if ((val1 === undefined || val2 === undefined) || (!val1 || !val2)) {
                                ctrl.$setValidity('dateBefore', true);
                                return;
                            };
                            var isArray = val2 instanceof Array;
                            var isValid = true;
                            var date1 = new Date(val1);
                            if (isArray && val2.length > 0) {
                                for (var i = 0; i < val2.length; i++) {
                                    if (val2[i]) {
                                        var date2 = new Date(val2[i]);
                                        isValid = isValid && (isInclusive ? date1 <= date2 : date1 < date2);
                                    }
                                    if (!isValid)
                                        break;
                                }
                            }
                            else {
                                if (val2) {
                                    var date2 = new Date(val2);
                                    isValid = isInclusive ? date1 <= date2 : date1 < date2;
                                }
                            }
                            ctrl.$setValidity('dateBefore', isValid);
                        };
                    // Watch the value to compare - trigger validate()
                    scope.$watch(attrs.dateBefore, function () {
                        validate(ctrl.$viewValue, scope.$eval(attrs.dateBefore));
                    });

                    ctrl.$parsers.unshift(function (value) {
                        validate(value, scope.$eval(attrs.dateBefore));
                        return value;
                    })
                }
        }}
    )
    .directive ('dateAfter',
        function(){
            return {
                require: 'ngModel',
                    link: function (scope, el, attrs, ctrl) {
                    var isInclusive = attrs.dateOrEquals ? scope.$eval(attrs.dateOrEquals) : false,
                        validate = function (val1, val2) {
                            if ((val1 === undefined || val2 === undefined) || (!val1 || !val2)) {
                                ctrl.$setValidity('dateAfter', true);
                                return;
                            };
                            var isArray = val2 instanceof Array;
                            var isValid = true;
                            var date1 = new Date(val1);
                            if (isArray && val2.length > 0) {
                                for (var i = 0; i < val2.length; i++) {
                                    if (val2[i]) {
                                        var date2 = new Date(val2[i]);
                                        isValid = isValid && (isInclusive ? date1 >= date2 : date1 > date2);
                                    }
                                    if (!isValid)
                                        break;
                                }
                            }
                            else {
                                if (val2) {
                                    var date2 = new Date(val2);
                                    isValid = isInclusive ? date1 >= date2 : date1 > date2;
                                }
                            }
                            ctrl.$setValidity('dateAfter', isValid);
                        };
                    // Watch the value to compare - trigger validate()
                    scope.$watch(attrs.dateAfter, function () {
                        validate(ctrl.$viewValue, scope.$eval(attrs.dateAfter));
                    });

                    ctrl.$parsers.unshift(function (value) {
                        validate(value, scope.$eval(attrs.dateAfter));
                        return value;
                    })
                }
        }}
    )
    .directive('validDate', ["$filter",function ($filter) {
        return {
            restrict: 'EAC',
            require: 'ngModel',
            link: function (scope, element, attrs, control) {
                var validate = function (viewValue) {
                    console.log ("validDate :"+viewValue);
                    var newDate = viewValue;
                    control.$setValidity("invalidDate", true);
                    newDate = $filter('date')(newDate, 'MM/dd/yyyy');
                    console.log ("validDate filter :"+newDate);
                    if (typeof newDate === "object" || newDate == "") return newDate;  // pass through if we clicked date from popup
                    if (!newDate.match(/^\d{1,2}\/\d{1,2}\/((\d{2})|(\d{4}))$/)) {
                        console.log ("FALSE");
                        control.$setValidity("invalidDate", false);
                    }
                    return viewValue;
                }
                control.$parsers.push(validate);
                control.$parsers.unshift(function (value) {
                    validate(value, scope.$eval(attrs.dateBefore));
                    return value;
                })
            }
        };
    }])
;
