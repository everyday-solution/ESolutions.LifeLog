(function ($) {

	$.fn.numericUpDown = function (up, down, step) {
		var value = parseFloat(this.val());
		var tb = this;

		up.click(function () {
			value += step;

			if (step % 1 == 0) {
				tb.val(value.toFixed(0));
			}
			else {
				tb.val(value.toFixed(1));
			}
		});

		down.click(function () {
			value -= step;

			if (step % 1 == 0) {
				tb.val(value.toFixed(0));
			}
			else {
				tb.val(value.toFixed(1));
			}
		});
	};
})(jQuery);