'use strict';

(function ($) {
  'use strict';

  function bootstrapTableSimpleExample() {
    var $demoBootstrapTable = $('#demo-bootstrap-table-1');
    if ($demoBootstrapTable.length) {
      $demoBootstrapTable.bootstrapTable({
        columns: [{
          field: 'name',
          title: 'Name'
        }, {
          field: 'position',
          title: 'Position'
        }, {
          field: 'salary',
          title: 'Salary'
        }],
        height: 265,
        url: '/employees.json'
      });

      $(window).on('resize', function (evt) {
        $demoBootstrapTable.bootstrapTable('resetView');
      });
    }
  }

  function bootstrapTableLayoutFixedExample() {
    var $demoBootstrapTable = $('#demo-bootstrap-table-2');
    if ($demoBootstrapTable.length) {
      $demoBootstrapTable.bootstrapTable({
        columns: [{
          align: 'left',
          field: 'name',
          title: 'Name'
        }, {
          align: 'center',
          field: 'position',
          title: 'Position'
        }, {
          align: 'right',
          field: 'salary',
          title: 'Salary'
        }],
        height: 265,
        url: '/employees.json'
      });

      $(window).on('resize', function (evt) {
        $demoBootstrapTable.bootstrapTable('resetView');
      });
    }
  }

  function bootstrapTableStripedExample() {
    var $demoBootstrapTable = $('#demo-bootstrap-table-3');
    if ($demoBootstrapTable.length) {
      $demoBootstrapTable.bootstrapTable({
        columns: [{
          align: 'left',
          field: 'name',
          title: 'Name'
        }, {
          align: 'left',
          field: 'position',
          title: 'Position'
        }, {
          align: 'right',
          field: 'salary',
          title: 'Salary'
        }],
        height: 265,
        striped: true,
        url: '/employees.json'
      });

      $(window).on('resize', function (evt) {
        $demoBootstrapTable.bootstrapTable('resetView');
      });
    }
  }

  function bootstrapTableRowStyle(row, index) {
    var contextualClasses = ['active', 'success', 'info', 'warning', 'danger'],
        contextualClass = index % 2 === 0 ? contextualClasses[index % 10 / 2] : '';

    return {
      classes: contextualClass
    };
  }

  function bootstrapTableRowStyleExample() {
    var $demoBootstrapTable = $('#demo-bootstrap-table-4');
    if ($demoBootstrapTable.length) {
      $demoBootstrapTable.bootstrapTable({
        columns: [{
          align: 'left',
          field: 'name',
          title: 'Name'
        }, {
          align: 'left',
          field: 'position',
          title: 'Position'
        }, {
          align: 'right',
          field: 'salary',
          title: 'Salary'
        }],
        height: 265,
        rowStyle: bootstrapTableRowStyle,
        url: '/employees.json'
      });

      $(window).on('resize', function (evt) {
        $demoBootstrapTable.bootstrapTable('resetView');
      });
    }
  }

  function bootstrapTableCustomCheckboxFormatter(value, row, index) {
    return '<label class="custom-control custom-control-primary custom-checkbox">' + '<input class="custom-control-input" type="checkbox" name="btSelectItem" data-index="' + index + '">' + '<span class="custom-control-indicator"></span>' + '</label>';
  }

  function bootstrapTableCustomCheckboxFormatterExample() {
    var $demoBootstrapTable = $('#demo-bootstrap-table-5');
    if ($demoBootstrapTable.length) {
      $demoBootstrapTable.bootstrapTable({
        columns: [{
          field: 'state',
          formatter: bootstrapTableCustomCheckboxFormatter
        }, {
          field: 'name',
          title: 'Name'
        }, {
          field: 'position',
          title: 'Position'
        }],
        height: 265,
        url: '/employees.json'
      });

      $(window).on('resize', function (evt) {
        $demoBootstrapTable.bootstrapTable('resetView');
      });
    }
  }

  function bootstrapTableSwitchFormatter(value, row, index) {
    return '<label class="switch switch-primary">' + '<input class="switch-input" type="checkbox" name="btSelectItem" data-index="' + index + '">' + '<span class="switch-track"></span>' + '<span class="switch-thumb"></span>' + '</label>';
  }

  function bootstrapTableSwitchFormatterExample() {
    var $demoBootstrapTable = $('#demo-bootstrap-table-6');
    if ($demoBootstrapTable.length) {
      $demoBootstrapTable.bootstrapTable({
        classes: 'table',
        columns: [{
          field: 'name',
          title: 'Name'
        }, {
          field: 'position',
          title: 'Position'
        }, {
          field: 'state',
          formatter: bootstrapTableSwitchFormatter
        }],
        height: 265,
        url: '/employees.json'
      });

      $(window).on('resize', function (evt) {
        $demoBootstrapTable.bootstrapTable('resetView');
      });
    }
  }

  function bootstrapTableFlagFormatter(value, row) {
    if (row.flag.length) {
      value = '<img class="img-flag" src="' + row.flag + '">' + value;
    }

    return value;
  }

  function bootstrapTableCustomSort(a, b) {
    a = parseInt(a.replace(/[.,%]/g, ''));
    b = parseInt(b.replace(/[.,%]/g, ''));

    if (a < b) return 1;
    if (a > b) return -1;

    return 0;
  }

  function bootstrapTableWithSortableColumnsExample() {
    var $demoBootstrapTable7 = $('#demo-bootstrap-table-7');
    $demoBootstrapTable7.bootstrapTable({
      columns: [{
        align: 'right',
        field: 'rank',
        sortable: false,
        title: 'Rank'
      }, {
        field: 'country',
        formatter: bootstrapTableFlagFormatter,
        sortable: false,
        title: 'Country'
      }, {
        align: 'right',
        field: 'continent',
        sortable: true,
        title: 'Continent'
      }, {
        align: 'right',
        field: 'region',
        sortable: true,
        title: 'Region'
      }, {
        align: 'right',
        field: 'year2016',
        sortable: true,
        sorter: bootstrapTableCustomSort,
        title: '2016'
      }, {
        align: 'right',
        field: 'year2015',
        sortable: true,
        sorter: bootstrapTableCustomSort,
        title: '2015'
      }, {
        align: 'right',
        field: 'change',
        sortable: true,
        sorter: bootstrapTableCustomSort,
        title: 'Change'
      }],
      height: 411,
      striped: true,
      url: '/population.json'
    });

    $(window).on('resize', function (evt) {
      $demoBootstrapTable7.bootstrapTable('resetView');
    });
  }

  function bootstrapTableWithToolbarAndPaginationExample() {
    var $demoBootstrapTable = $('#demo-bootstrap-table-8');
    if ($demoBootstrapTable.length) {
      $demoBootstrapTable.bootstrapTable({
        buttonsClass: 'primary',
        columns: [{
          align: 'right',
          field: 'rank',
          sortable: false,
          title: 'Rank'
        }, {
          field: 'country',
          formatter: bootstrapTableFlagFormatter,
          sortable: false,
          title: 'Country'
        }, {
          align: 'right',
          field: 'continent',
          sortable: true,
          title: 'Continent'
        }, {
          align: 'right',
          field: 'region',
          sortable: true,
          title: 'Region'
        }, {
          align: 'right',
          field: 'year2016',
          sortable: true,
          sorter: bootstrapTableCustomSort,
          title: '2016'
        }, {
          align: 'right',
          field: 'year2015',
          sortable: true,
          sorter: bootstrapTableCustomSort,
          title: '2015'
        }, {
          align: 'right',
          field: 'change',
          sortable: true,
          sorter: bootstrapTableCustomSort,
          title: 'Change'
        }],
        icons: {
          columns: 'icon-list-ul',
          paginationSwitchDown: 'icon-expand',
          paginationSwitchUp: 'icon-compress',
          refresh: 'glyphicon-refresh icon-refresh',
          toggle: 'icon-columns'
        },
        iconsPrefix: 'icon',
        minimumCountColumns: 2,
        pageList: [],
        pagination: true,
        search: true,
        showColumns: true,
        showFooter: false,
        showPaginationSwitch: true,
        showRefresh: true,
        showToggle: true,
        striped: true,
        url: '/population.json'
      });

      $(window).on('resize', function (evt) {
        $demoBootstrapTable.bootstrapTable('resetView');
      });
    }
  }

  function datatablesBasicTableExample() {
    var $datatables = $('#demo-datatables-1');
    $datatables.DataTable({
      dom: "<'row'<'col-sm-6'i><'col-sm-6'f>>" + "<'table-responsive'tr>" + "<'row'<'col-sm-6'l><'col-sm-6'p>>",
      language: {
        paginate: {
          previous: '&laquo;',
          next: '&raquo;'
        },
        search: "_INPUT_",
        searchPlaceholder: "Search…"
      },
      order: [[5, "desc"]]
    });
  }

  function datatablesComplexHeaderExample() {
    var $datatables = $('#demo-datatables-2');
    $datatables.DataTable({
      dom: "<'row'<'col-sm-6'i><'col-sm-6'f>>" + "<'table-responsive'tr>" + "<'row'<'col-sm-6'l><'col-sm-6'p>>",
      language: {
        paginate: {
          previous: '&laquo;',
          next: '&raquo;'
        },
        search: "_INPUT_",
        searchPlaceholder: "Search…"
      },
      order: [[2, "desc"]]
    });
  }

  function datatablesIndividualColumnSearchingExample() {
    var $datatables = $('#demo-datatables-3');
    if ($datatables.length) {
      var DataTable = $.fn.dataTable;
      $.extend(true, DataTable.ext.classes, {
        sWrapper: "dataTables_wrapper dt-bootstrap"
      });

      $('#demo-datatables-3 tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input class="form-control input-sm" type="text" placeholder="Search ' + title + '" />');
      });

      // DataTable
      var $datatables = $datatables.DataTable({
        dom: "<'row'<'col-sm-12'i>>" + "<'table-responsive'tr>" + "<'row'<'col-sm-6'l><'col-sm-6'p>>",
        language: {
          paginate: {
            previous: '&laquo;',
            next: '&raquo;'
          },
          search: "_INPUT_",
          searchPlaceholder: "Search…"
        },
        order: [[2, "desc"]]
      });

      // Apply the search
      $datatables.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
          if (that.search() !== this.value) {
            that.search(this.value).draw();
          }
        });
      });
    }
  }

  function datatablesSelect2ColumnSearchingExample() {
    var $datatables = $('#demo-datatables-4');
    if ($datatables.length) {
      var DataTable = $.fn.dataTable;
      $.extend(true, DataTable.ext.classes, {
        sWrapper: "dataTables_wrapper dt-bootstrap"
      });

      $datatables.DataTable({
        dom: "<'row'<'col-sm-12'i>>" + "<'table-responsive'tr>" + "<'row'<'col-sm-6'l><'col-sm-6'p>>",
        language: {
          paginate: {
            previous: '&laquo;',
            next: '&raquo;'
          }
        },
        initComplete: function initComplete() {
          this.api().columns().every(function () {
            var column = this;
            var header = column.header();
            var select = $('<select class="demo-select2"><option value="">' + $(header).text() + '</option></select>').appendTo($(column.footer()).empty()).on('change', function () {
              var val = $.fn.dataTable.util.escapeRegex($(this).val());

              column.search(val ? '^' + val + '$' : '', true, false).draw();
            });

            column.data().unique().sort().each(function (d, j) {
              select.append('<option value="' + d + '">' + d + '</option>');
            });
          });
        }
      });
      $(".demo-select2").select2();
    }
  }

  function datatablesAlternativePaginationExample() {
    var $datatables = $('#demo-datatables-5');
    $datatables.DataTable({
      dom: "<'row'<'col-sm-6'l><'col-sm-6'f>>" + "<'table-responsive'tr>" + "<'row'<'col-sm-12'p>>",
      language: {
        paginate: {
          previous: '&laquo;',
          next: '&raquo;'
        },
        search: "_INPUT_",
        searchPlaceholder: "Search…"
      },
      "pagingType": "full_numbers",
      order: [[2, "desc"]]
    });
  }

  function datatablesButtonsExample() {
    var DataTable = $.fn.dataTable;
    $.extend(true, DataTable.Buttons.defaults, {
      dom: {
        button: {
          className: 'btn btn-primary btn-sm'
        }
      }
    });

    var $datatablesButtons = $('#demo-datatables-buttons-1').DataTable({
      buttons: ['print', 'copy', 'pdf', 'excel', 'colvis'],
      lengthChange: false,
      responsive: true,
      language: {
        paginate: {
          previous: '&laquo;',
          next: '&raquo;'
        },
        search: "_INPUT_",
        searchPlaceholder: "Search…"
      },
      order: [[6, "desc"]]
    });

    $datatablesButtons.buttons().container().appendTo('#demo-datatables-buttons-1_wrapper .col-sm-6:eq(0)');
  }

  function datatablesButtonsTableBorderedExample() {
    var DataTable = $.fn.dataTable;
    $.extend(true, DataTable.Buttons.defaults, {
      dom: {
        button: {
          className: 'btn btn-outline-primary btn-sm'
        }
      }
    });

    var $datatablesButtons = $('#demo-datatables-buttons-2').DataTable({
      buttons: ['print', 'copy', 'pdf', 'excel', 'colvis'],
      lengthChange: false,
      responsive: true,
      language: {
        paginate: {
          previous: '&laquo;',
          next: '&raquo;'
        },
        search: "_INPUT_",
        searchPlaceholder: "Search…"
      },
      order: [[6, "desc"]]
    });

    $datatablesButtons.buttons().container().appendTo('#demo-datatables-buttons-2_wrapper .col-sm-6:eq(0)');
  }

  function datatablesColreorderExample() {
    var $datatablesColreorder = $('#demo-datatables-colreorder-1');
    $datatablesColreorder.DataTable({
      colReorder: true,
      responsive: true,
      dom: "<'row'<'col-sm-6'i><'col-sm-6'f>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-6'l><'col-sm-6'p>>",
      language: {
        paginate: {
          previous: '&laquo;',
          next: '&raquo;'
        },
        search: "_INPUT_",
        searchPlaceholder: "Search…"
      }
    });
  }

  function datatablesColreorderStateSavingExample() {
    var $datatablesColreorder = $('#demo-datatables-colreorder-2');
    $datatablesColreorder.DataTable({
      colReorder: true,
      responsive: true,
      stateSave: true,
      dom: "<'row'<'col-sm-6'i><'col-sm-6'f>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-6'l><'col-sm-6'p>>",
      language: {
        paginate: {
          previous: '&laquo;',
          next: '&raquo;'
        },
        search: "_INPUT_",
        searchPlaceholder: "Search…"
      }
    });
  }

  function datatablesFixedheaderExample() {
    var $datatablesFixedheader = $('#demo-datatables-fixedheader-1');
    if ($datatablesFixedheader.length) {
      $datatablesFixedheader = $datatablesFixedheader.DataTable({
        fixedHeader: true,
        responsive: true,
        dom: "<'row'<'col-sm-6'i><'col-sm-6'f>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-6'l><'col-sm-6'p>>",
        language: {
          paginate: {
            previous: '&laquo;',
            next: '&raquo;'
          },
          search: "_INPUT_",
          searchPlaceholder: "Search…"
        }
      });

      var adjustFixedHeaderTimeoutId;
      var adjustFixedHeader = function adjustFixedHeader() {
        if (adjustFixedHeaderTimeoutId) {
          clearTimeout(adjustFixedHeaderTimeoutId);
        }

        adjustFixedHeaderTimeoutId = setTimeout(function () {
          $datatablesFixedheader.columns.adjust().responsive.recalc().fixedHeader.adjust();
        }, 300);
      };

      $(window).on('resize', adjustFixedHeader);
      $('button.sidenav-toggler').on('click', adjustFixedHeader);

      adjustFixedHeader();
    }
  }

  function datatablesFixedheaderTableBorderedExample() {
    var $datatablesFixedheader = $('#demo-datatables-fixedheader-2');
    if ($datatablesFixedheader.length) {
      $datatablesFixedheader = $datatablesFixedheader.DataTable({
        fixedHeader: true,
        responsive: true,
        dom: "<'row'<'col-sm-6'l><'col-sm-6'f>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-6'i><'col-sm-6'p>>",
        language: {
          paginate: {
            previous: '&laquo;',
            next: '&raquo;'
          },
          search: "_INPUT_",
          searchPlaceholder: "Search…"
        }
      });

      var adjustFixedHeaderTimeoutId;
      var adjustFixedHeader = function adjustFixedHeader() {
        if (adjustFixedHeaderTimeoutId) {
          clearTimeout(adjustFixedHeaderTimeoutId);
        }

        adjustFixedHeaderTimeoutId = setTimeout(function () {
          $datatablesFixedheader.columns.adjust().responsive.recalc().fixedHeader.adjust();
        }, 300);
      };

      $(window).on('resize', adjustFixedHeader);
      $('button.sidenav-toggler').on('click', adjustFixedHeader);

      adjustFixedHeader();
    }
  }

  function datatablesResponsiveExample() {
    var $datatablesResponsive = $('#demo-datatables-responsive-1');
    $datatablesResponsive.DataTable({
      responsive: true,
      dom: "<'row'<'col-sm-6'i><'col-sm-6'f>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-6'><'col-sm-6'p>>",
      language: {
        paginate: {
          previous: '&laquo;',
          next: '&raquo;'
        },
        search: "_INPUT_",
        searchPlaceholder: "Search…"
      },
      order: [[6, "desc"]]
    });
  }

  function datatablesResponsiveTableBorderedExample() {
    var $datatablesResponsive = $('#demo-datatables-responsive-2');
    $datatablesResponsive.DataTable({
      responsive: true,
      dom: "<'row'<'col-sm-6 col-sm-push-6'i><'col-sm-6 col-md-pull-6'f>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-6'l><'col-sm-6'p>>",
      language: {
        paginate: {
          previous: '&laquo;',
          next: '&raquo;'
        },
        search: "_INPUT_",
        searchPlaceholder: "Search…"
      },
      order: [[6, "desc"]]
    });
  }

  function datatablesRowreorderExample() {
    var $datatablesRowreorder = $('#demo-datatables-rowreorder-1');
    $datatablesRowreorder.DataTable({
      rowReorder: true,
      dom: "<'row'<'col-sm-6'i><'col-sm-6'f>>" + "<'table-responsive'tr>" + "<'row'<'col-sm-6'><'col-sm-6'p>>",
      language: {
        paginate: {
          previous: '&laquo;',
          next: '&raquo;'
        },
        search: "_INPUT_",
        searchPlaceholder: "Search…"
      }
    });
  }

  function datatablesRowreorderTableBorderedExample() {
    var DataTable = $.fn.dataTable;
    $.extend(true, DataTable.Buttons.defaults, {
      dom: {
        button: {
          className: 'btn btn-primary btn-sm'
        }
      }
    });

    var $datatablesRowreorder = $('#demo-datatables-rowreorder-2').DataTable({
      buttons: ['print', 'copy', 'pdf'],
      rowReorder: true,
      dom: "<'row'<'col-sm-6'><'col-sm-6'f>>" + "<'table-responsive'tr>" + "<'row'<'col-sm-6'i><'col-sm-6'p>>",
      language: {
        paginate: {
          previous: '&laquo;',
          next: '&raquo;'
        },
        search: "_INPUT_",
        searchPlaceholder: "Search…"
      }
    });

    $datatablesRowreorder.buttons().container().appendTo('#demo-datatables-rowreorder-2_wrapper .col-sm-6:eq(0)');
  }

  function datatablesScrollerExample() {
    var $datatablesFixedheader = $('#demo-datatables-scroller-1');
    if ($datatablesFixedheader.length) {
      $datatablesFixedheader = $datatablesFixedheader.DataTable({
        deferRender: true,
        scrollY: 370,
        scrollCollapse: true,
        scroller: true,
        responsive: true,
        dom: "<'row'<'col-sm-6'i><'col-sm-6'f>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-6'l><'col-sm-6'p>>",
        language: {
          paginate: {
            previous: '&laquo;',
            next: '&raquo;'
          },
          search: "_INPUT_",
          searchPlaceholder: "Search…"
        }
      });

      $(window).on('resize', function (evt) {
        setTimeout(function () {
          $datatablesFixedheader.columns.adjust().responsive.recalc();
        }, 150);
      });
    }
  }

  function datatablesScrollerTableBorderedExample() {
    var $datatablesFixedheader = $('#demo-datatables-scroller-2');
    if ($datatablesFixedheader.length) {
      $datatablesFixedheader = $datatablesFixedheader.DataTable({
        deferRender: true,
        scrollY: 369,
        scrollCollapse: true,
        scroller: true,
        responsive: true,
        dom: "<'row'<'col-sm-6 col-sm-push-6'i><'col-sm-6 col-md-pull-6'f>>" + "<'row'<'col-sm-12'tr>>",
        language: {
          paginate: {
            previous: '&laquo;',
            next: '&raquo;'
          },
          search: "_INPUT_",
          searchPlaceholder: "Search…"
        }
      });

      $(window).on('resize', function (evt) {
        setTimeout(function () {
          $datatablesFixedheader.columns.adjust().responsive.recalc();
        }, 150);
      });
    }
  }


  // Bootstrap Table
  bootstrapTableSimpleExample();
  bootstrapTableLayoutFixedExample();
  bootstrapTableStripedExample();
  bootstrapTableRowStyleExample();
  bootstrapTableCustomCheckboxFormatterExample();
  bootstrapTableSwitchFormatterExample();
  bootstrapTableWithSortableColumnsExample();
  bootstrapTableWithToolbarAndPaginationExample();

  // DataTables
  datatablesBasicTableExample();
  datatablesComplexHeaderExample();
  datatablesIndividualColumnSearchingExample();
  datatablesSelect2ColumnSearchingExample();
  datatablesAlternativePaginationExample();
  datatablesButtonsExample();
  datatablesButtonsTableBorderedExample();
  datatablesColreorderExample();
  datatablesColreorderStateSavingExample();
  datatablesFixedheaderExample();
  datatablesFixedheaderTableBorderedExample();
  datatablesResponsiveExample();
  datatablesResponsiveTableBorderedExample();
  datatablesRowreorderExample();
  datatablesRowreorderTableBorderedExample();
  datatablesScrollerExample();
  datatablesScrollerTableBorderedExample();

})(jQuery);
