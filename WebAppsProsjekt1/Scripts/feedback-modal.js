function showFeedbackModal(inputString, color, delay) {
	$("#feedback-modal").find('p').html(inputString);
	$("#feedback-modal").css('background-color', color);
	$("#feedback-modal").slideToggle().slideDown();
	$("#feedback-modal-close").on("click", function () {
		$("#feedback-modal").remove();
	});
	$("#feedback-modal").delay(delay).slideToggle().slideUp();
}