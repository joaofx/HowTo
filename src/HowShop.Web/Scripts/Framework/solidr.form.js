SolidR.form = (function($, undefined) {

    'use strict';

    // TODO: depending on bootstrap classes. think in a way to configure this for apps that does not use bootstrap
    // TODO: unit tests
    // TODO: SolidR.Form namespace
    var formSummarySelector = ".form-summary";
    var $form = null;

    var findFormSummary = function() {
        var $summary;

        if ($form === null || $form.length === 0) {
            return $(formSummarySelector);
        }

        $summary = $form.find(formSummarySelector);

        if ($summary.length === 0)
        // could not find summary inside the form, lets search for the closest outside form
            $summary = $form.closest(formSummarySelector);

        if ($summary.length === 0)
        // could not find summary outside form, is there any on the page?
            $summary = $(formSummarySelector);

        return $summary;
    };

    var highlightFields = function(response) {
        $('.form-group').removeClass('has-error');

        $.each(response, function(index, val) {
            var nameSelector = '[name = "' + val.PropertyName.replace(/(:|\.|\[|\])/g, "\\$1") + '"]';
            var idSelector = '#' + val.PropertyName.replace(/(:|\.|\[|\])/g, "\\$1");

            var $el = $(nameSelector) || $(idSelector);

            if (response.length > 0) {
                $el.closest('.form-group').addClass('has-error');
            }
        });
    };

    var showSummary = function(response) {

        var $summary = findFormSummary()
            .empty()
            .removeClass('hidden');

        for (var i = 0, len = response.length; i < len; i++) {
            var $li = $('<li></li>').text(response[i].ErrorMessage);
            $li.appendTo($summary);
        }
    };

    var handleException = function(response) {
        var data = JSON.parse(response.responseText);

        $(findFormSummary())
            .empty()
            .append('<span class="glyphicon glyphicon-warning-sign"><strong class="error-message">' + data.ErrorMessage + '</strong></span>')
            .removeClass('hidden');
    };

    var handleInvalid = function(response) {
        try {
            var data = JSON.parse(response.responseText);
            highlightFields(data);
            showSummary(data);
        } catch (e) {
            handleException(response);
        }
    };

    var onError = function(response) {
        if (response.status === 400) {
            handleInvalid(response);
        } else {
            handleException(response);
        }
    };

    var redirect = function(data) {
        if (data.redirect) {
            window.location = data.redirect;
        } else {
            window.scrollTo(0, 0);
            window.location.reload();
        }
    };

    var post = function(action, $button, formData) {

        // find the closest form on the button that was submitted
        if ($form === null || $form === undefined) {
            $form = $button.closest("form");
        }

        $button.prop('disabled', true);
        $(window).unbind();

        $.ajax({
            url: action,
            type: 'post',
            data: formData,
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            dataType: 'json',
            statusCode: {
                200: redirect
            },
            complete: function() {
                $button.prop('disabled', false);
            }
        }).error(function(response) {
            onError(response, $button.closest('form'));
        });

        return false;
    };

    //$('form[method=post]').not('.no-ajax').not('[data-custom=true]').on('submit', function () {
    $(document).on("submit", "form[method=post]", function() {
        var $this = $(this);
        $form = $this;

        if ($form.is(".no-ajax") || $form.is('.no-ajax') || $form.is('[data-custom=true]') || $form.is('.contained-form')) {
            return true;
        }

        var submitBtn = $(this).find('[type="submit"]');
        var formData = $this.serialize();
        var action = $this.attr('action');

        $this.find('div').removeClass('has-error');

        post(action, submitBtn, formData);

        return false;
    });

    var setForm = function(form) {
        $form = form;
    };

    $(document).on("bind", "form", function() {
        var $form = $(this);
        $form.att("novalidate", "novalidate");
    });

    return {
        onError: onError,
        post: post,
        setForm: setForm
    };

})(jQuery);