$(document).ready(function () {
    var $products = $('.grid-products'),
      $variants = $('.grid-variants'),
      $filters = $("#filters input[type='checkbox']"),
      product_filter = new ProductFilterLevel2($products, $variants, $filters);
    product_filter.init();
});

function ProductFilterLevel2(products, variants, filters) {
    var _this = this;

    this.init = function () {
        this.products = products;
        this.variants = variants;
        this.filters = filters;
        this.bindEvents();
    };

    this.bindEvents = function () {
        this.filters.click(function () {
            //alert('Clicked...');
            _this.products.hide();

            var filteredProducts = _this.variants;
            var filterAttributes = $('.filter-attributes');
            var i = 0;
            filterAttributes.each(function () {
                var selectedFilters = $(this).find('input:checked');
                if (selectedFilters.length) {
                    var selectedFiltersValues = [];
                    var selectedFiltersPriceValues = [];

                    selectedFilters.each(function () {

                        var currentFilter = $(this);
                        if (currentFilter.attr('name') == 'brand') {

                            selectedFiltersValues.push("[" + currentFilter.attr('name') + "='" + currentFilter.val() + "']");
                        }
                       else if (currentFilter.attr('name') == 'colour') {
                         debugger
                            selectedFiltersValues.push("[" + currentFilter.attr('name') + "='" + currentFilter.val() + "']");
                        }
                       else if (currentFilter.attr('name') == 'ram') {
                            var res = currentFilter.val().split("-");
                            var min = res[0];
                            var max = res[1];
                            filteredProducts.each(function () {
                                var FilterPrice = $(this);
                                var RPrice = FilterPrice.attr('ram');
                                var RP = parseInt(RPrice) * 1;
                                var MP = parseInt(min) * 1;
                                var Mx = parseInt(max) * 1;
                                var FilterPrise = false;
                                //if (RP > MP && RP < Mx) {
                                if (RP >= MP && RP <= Mx) {
                                    FilterPrise = true;
                                }
                                else { FilterPrise = false; }
                                if (FilterPrise == true) {
                                    i++;

                                    FilterPrice.parent().parent().parent().parent().show();
                                }
                            });


                        }

                      else  if (currentFilter.attr('name') == 'storage') {

                            var res = currentFilter.val().split("-");
                            var min = res[0];
                            var max = res[1];
                            filteredProducts.each(function () {
                                var FilterPrice = $(this);
                                var RPrice = FilterPrice.attr('storage');

                                var RP = parseInt(RPrice) * 1;
                                var MP = parseInt(min) * 1;
                                var Mx = parseInt(max) * 1;
                                var FilterPrise = false;
                                if (RP >= MP && RP <= Mx) {
                                    FilterPrise = true;
                                }
                                else { FilterPrise = false; }
                                if (FilterPrise == true) {
                                    i++;

                                    FilterPrice.parent().parent().parent().parent().show();
                                }
                            });
                        }
                      else  if (currentFilter.attr('name') == 'price') {
                            //alert('hello Price');
                            var res = currentFilter.val().split("-");
                            var min = res[0];
                            var max = res[1];
                            filteredProducts.each(function () {
                                var FilterPrice = $(this);
                                var RPrice = FilterPrice.attr('price');

                                var RP = parseInt(RPrice) * 1;
                                var MP = parseInt(min) * 1;
                                var Mx = parseInt(max) * 1;
                                var FilterPrise = false;
                                if (RP >= MP && RP <= Mx) {
                                //if (RP > MP && RP < Mx) {
                                    FilterPrise = true;
                                }
                                else { FilterPrise = false; }
                                if (FilterPrise == true) {
                                    i++;

                                    FilterPrice.parent().parent().parent().parent().show();
                                }
                            });
                        }
                    });
                    filteredProducts = filteredProducts.filter(selectedFiltersValues.join(','));
                  

                }
            });


            // filteredProducts.parent().show();
            filteredProducts.parent().parent().parent().parent().show();
        });
        //$('.chkClick').click(this.filterGridProducts);
        //$('#none').click(this.removeAllFilters);
    };


    this.filterGridProducts = function () {
        //hide all
        _this.products.hide();
        var filteredProducts = _this.variants;
        //filter by colour, size, shape etc
        var filterAttributes = $('.filter-attributes');
        // for each attribute check the corresponding attribute filters selected
        filterAttributes.each(function () {
            var selectedFilters = $(this).find('input:checked');
            // if selected filter by the attribute
            if (selectedFilters.length) {
                var selectedFiltersValues = [];

                selectedFilters.each(function () {
                    var currentFilter = $(this);

                    selectedFiltersValues.push("[data-" + currentFilter.attr('name') + "='" + currentFilter.val() + "']");
                });
                filteredProducts = filteredProducts.filter(selectedFiltersValues.join(','));
            }
        });
        filteredProducts.parent().show();
    };

    this.removeAllFilters = function () {
        _this.filters.prop('checked', false);
        _this.products.show();
    }
}