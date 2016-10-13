//'use strict';

var SolidRform = (function ($) {

    var formSummarySelector = '#validationSummary';
    var $form = null;
    var scope = null;

    var getFixedValidationSummary = function () {
        return $(formSummarySelector, scope);
    }

    var findFormSummary = function () {
        var $summary = null;

        if ($form === null) {
            return getFixedValidationSummary();
        }

        $summary = $form.find(".form-summary", scope);

        if ($summary.length === 0) {
            return getFixedValidationSummary();
        }

        return $summary;
    }

    var highlightFields = function (response) {

        $('.form-group', scope).removeClass('has-error');

        $.each(response, function (index, val) {
            var nameSelector = '[name = "' + val.PropertyName.replace(/(:|\.|\[|\])/g, "\\$1") + '"]';
            var idSelector = '#' + val.PropertyName.replace(/(:|\.|\[|\])/g, "\\$1");

            var $el = $(nameSelector, scope) || $(idSelector, scope);

            if (response.length > 0) {
                $el.closest('.form-group').addClass('has-error');
            }
        });
    };

    var showSummary = function (response) {

        var $summary = findFormSummary()
            .empty()
            .removeClass('hidden')
            .append('<span class="glyphicon glyphicon-warning-sign"><strong class="error-message">The following errors occurred with your submission:</strong></span>');

        _.each(response, function (error) {
            var $li = $('<li></li>', scope).text(error.ErrorMessage);
            $li.appendTo($summary);
        });
    };

    var handleException = function (response) {
        var data = JSON.parse(response.responseText);

        $(findFormSummary())
            .empty()
            .append('<span class="glyphicon glyphicon-warning-sign"><strong class="error-message">' + data.ErrorMessage + '</strong></span>')
            .removeClass('hidden');
    };

    var handleInvalid = function (response) {
        try {
            var data = JSON.parse(response.responseText);
            highlightFields(data);
            showSummary(data);
            window.scrollTo(0, 0); // TODO: scroll to form element
        } catch (e) {
            handleException(response);
        }
    };

    var onError = function (response, scopeId) {
        scope = (scopeId && typeof (scope) === 'string') || "";

        if (response.status === 400) {
            handleInvalid(response);
        } else {
            handleException(response);
        }
    }

    var redirect = function (data) {
        if (data.redirect) {
            window.location = data.redirect;
        } else {
            window.scrollTo(0, 0);
            window.location.reload();
        }
    };

    var post = function (action, $button, formData) {

        // TODO: better way to set form
        if ($form == null || $form == undefined) {
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
            complete: function () {
                $button.prop('disabled', false);
            }
        }).error(function (response) {
            onError(response, $button.closest('form'));
        });

        return false;
    }

    //$('form[method=post]').not('.no-ajax').not('[data-custom=true]').on('submit', function () {
    $(document).on("submit", "form[method=post]", function () {
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

    var setForm = function (form) {
        $form = form;
    }

    $(document).on("bind", "form", function () {
        var $form = $(this);
        $form.att("novalidate", "novalidate");
    });

    // exposing that can be used for others components
    return {
        onError: onError,
        post: post,
        setForm: setForm
    }

})(jQuery);