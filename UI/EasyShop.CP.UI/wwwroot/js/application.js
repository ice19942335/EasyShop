'use strict';

(function ($) {
  'use strict';

  var App = {
    Constants: {
      MEDIA_QUERY_BREAKPOINT: '992px',
      TRANSITION_DELAY: 400,
      TRANSITION_DURATION: 400
    },
    CssClasses: {
      LAYOUT: 'layout',
      LAYOUT_CONTENT: 'layout-content',
      LAYOUT_SIDEBAR: 'layout-sidebar',
      LAYOUT_SIDEBAR_COLLAPSED: 'layout-sidebar-collapsed',

      SIDENAV: 'sidenav',
      SIDENAV_BTN: 'sidenav-toggler',
      SIDENAV_COLLAPSED: 'sidenav-collapsed',

      SEARCH_FORM: 'navbar-search',
      SEARCH_FORM_BTN: 'navbar-search-toggler',
      SEARCH_FORM_COLLAPSED: 'navbar-search-collapsed',

      CUSTOM_SCROLLBAR: 'custom-scrollbar',
      COLLAPSED: 'collapsed'
    },
    Options: {
      // Custom scrollbar options
      CUSTOM_SCROLLBAR_DISTANCE: '4px',
      CUSTOM_SCROLLBAR_HEIGHT: '100%',
      CUSTOM_SCROLLBAR_SIZE: '7px',
      CUSTOM_SCROLLBAR_TOUCH_SCROLL_STEP: 50,
      CUSTOM_SCROLLBAR_WHEEL_STEP: 10,
      CUSTOM_SCROLLBAR_WIDTH: '100%',
      CUSTOM_SCROLLBAR_CLASS: 'custom-scrollbar',
      CUSTOM_SCROLLBAR_BAR_CLASS: 'custom-scrollbar-gripper',
      CUSTOM_SCROLLBAR_RAIL_CLASS: 'custom-scrollbar-track',
      CUSTOM_SCROLLBAR_WRAPPER_CLASS: 'custom-scrollable-area',

      // Side navigation options
      SIDENAV_CLASS: 'sidenav',
      SIDENAV_ACTIVE_CLASS: 'open',
      SIDENAV_COLLAPSE_CLASS: 'collapse',
      SIDENAV_COLLAPSE_IN_CLASS: 'in',
      SIDENAV_COLLAPSING_CLASS: 'collapsing',

      // Select2 options
      SELECT2_THEME: 'bootstrap',
      SELECT2_WIDTH: '100%'
    },
    KeyCodes: {
      S: 83,
      OPEN_SQUARE_BRACKET: 219,
      CLOSE_SQUARE_BRACKET: 221
    },
    init: function init() {
      this.$document = $(document);
      this.$layout = $('.' + this.CssClasses.LAYOUT);
      this.$content = $('.' + this.CssClasses.LAYOUT_CONTENT);
      this.$sidebar = $('.' + this.CssClasses.LAYOUT_SIDEBAR);
      this.$sideNav = $('.' + this.CssClasses.SIDENAV);
      this.$sideNavBtn = $('.' + this.CssClasses.SIDENAV_BTN);
      this.$scrollableArea = $('.' + this.CssClasses.CUSTOM_SCROLLBAR);
      this.$searchForm = $('.' + this.CssClasses.SEARCH_FORM);
      this.$searchFormBtn = $('.' + this.CssClasses.SEARCH_FORM_BTN);

      var mediaQueryString = '(max-width: ' + this.Constants.MEDIA_QUERY_BREAKPOINT + ')';
      this.mediaQueryList = window.matchMedia(mediaQueryString);

      if (this.isSmallDevice()) {
        this.collapseSideNav();
      }

      this.createSideNav().createCustomScrollbar().initPlugins().bindEvents();
    },
    bindEvents: function bindEvents() {
      this.$document.on('keydown', this.handleKeyboardEvent.bind(this));
      this.$sideNavBtn.on('click', this.handleSideNavToggle.bind(this));
      this.$searchFormBtn.on('click', this.handleSearchFormToggle.bind(this));

      this.mediaQueryList.addListener(this.handleMediaQueryChange.bind(this));
    },
    handleKeyboardEvent: function handleKeyboardEvent(evt) {
      if (/input|textarea/i.test(evt.target.tagName)) return;

      switch (evt.keyCode) {
        case this.KeyCodes.S:
          this.toggleSearchForm();
          break;
        case this.KeyCodes.OPEN_SQUARE_BRACKET:
          this.toggleSideNav();
          break;
      }
    },
    handleSideNavToggle: function handleSideNavToggle(evt) {
      this.toggleSideNav();
      evt.preventDefault();
    },
    handleSearchFormToggle: function handleSearchFormToggle(evt) {
      this.toggleSearchForm();
      evt.preventDefault();
    },
    handleMediaQueryChange: function handleMediaQueryChange(evt) {
      this[this.isSmallDevice() ? 'collapseSideNav' : 'expandSideNav']();
    },
    isSmallDevice: function isSmallDevice() {
      return this.mediaQueryList.matches;
    },
    collapseSideNav: function collapseSideNav() {
      var startEvent = $.Event('collapse-start');

      this.$layout.addClass(this.CssClasses.LAYOUT_SIDEBAR_COLLAPSED);
      this.$sideNav.trigger(startEvent).hide();

      this.$sideNav.addClass(this.CssClasses.SIDENAV_COLLAPSED);
      this.$sideNavBtn.addClass(this.CssClasses.COLLAPSED);

      if (this.transitionTimeoutId) {
        clearTimeout(this.transitionTimeoutId);
      }

      this.transitionTimeoutId = setTimeout(function () {
        this.$sideNav.fadeIn(this.Constants.TRANSITION_DURATION).trigger('collapse-end');
      }.bind(this), this.Constants.TRANSITION_DELAY);

      this.$sideNav.attr('aria-expanded', false);
      this.$sideNavBtn.attr('aria-expanded', false).attr('title', 'Expand sidenav ( [ )');
    },
    expandSideNav: function expandSideNav() {
      var startEvent = $.Event('expand-start');

      this.$layout.removeClass(this.CssClasses.LAYOUT_SIDEBAR_COLLAPSED);
      this.$sideNav.trigger(startEvent).hide();

      this.$sideNav.removeClass(this.CssClasses.SIDENAV_COLLAPSED);
      this.$sideNavBtn.removeClass(this.CssClasses.COLLAPSED);

      if (this.transitionTimeoutId) {
        clearTimeout(this.transitionTimeoutId);
      }

      this.transitionTimeoutId = setTimeout(function () {
        this.$sideNav.fadeIn(this.Constants.TRANSITION_DURATION).trigger('expand-end');
      }.bind(this), this.Constants.TRANSITION_DELAY);

      this.$sideNav.attr('aria-expanded', true);
      this.$sideNavBtn.attr('aria-expanded', true).attr('title', 'Collapse sidenav ( [ )');
    },
    isSideNavCollapsed: function isSideNavCollapsed() {
      return this.$sideNav.hasClass(this.CssClasses.SIDENAV_COLLAPSED);
    },
    toggleSideNav: function toggleSideNav() {
      this[this.isSideNavCollapsed() ? 'expandSideNav' : 'collapseSideNav']();
    },
    isSearchFormCollapsed: function isSearchFormCollapsed() {
      return this.$searchForm.hasClass(this.CssClasses.SEARCH_FORM_COLLAPSED);
    },
    toggleSearchForm: function toggleSearchForm() {
      this.$searchForm.toggleClass(this.CssClasses.SEARCH_FORM_COLLAPSED);
      this.$searchFormBtn.toggleClass(this.CssClasses.COLLAPSED);

      if (this.isSearchFormCollapsed()) {
        this.$searchForm.attr('aria-expanded', false);
        this.$searchFormBtn.attr('aria-expanded', false).attr('title', 'Expand search form ( S )');
      } else {
        this.$searchForm.attr('aria-expanded', true);
        this.$searchFormBtn.attr('aria-expanded', true).attr('title', 'Collapse search form ( S )');
      }
    },
    getCreateOptions: function getCreateOptions(prefix) {
      var regex = new RegExp('^' + prefix + '(_)?', 'i'),
          options = {};

      $.each(this.Options, function (key, val) {
        if (regex.test(key)) {
          key = key.replace(regex, '').replace(/_/g, '-');
          key = $.camelCase(key.toLowerCase());
          options[key] = val;
        }
      });

      return options;
    },
    getSideNavOptions: function getSideNavOptions() {
      return this.getCreateOptions('sidenav');
    },
    createSideNav: function createSideNav() {
      var options = this.getSideNavOptions();
      this.$sideNav.metisMenu(options);

      return this;
    },
    getCustomScrollbarOptions: function getCustomScrollbarOptions() {
      return this.getCreateOptions('custom_scrollbar');
    },
    createCustomScrollbar: function createCustomScrollbar() {
      var options = this.getCustomScrollbarOptions();
      this.$scrollableArea.slimScroll(options);

      return this;
    },
    getSelect2Options: function getSelect2Options() {
      return this.getCreateOptions('select2');
    },
    initSelect2: function initSelect2() {
      var Select2 = $.fn.select2,
          options = this.getSelect2Options();

      $.each(options, function (key, value) {
        Select2.defaults.set(key, value);
      });
    },
    initPlugins: function initPlugins() {
      this.initSelect2();

      return this;
    }
  };

  App.init();
})(jQuery);
