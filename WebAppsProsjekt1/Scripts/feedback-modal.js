function showFeedbackModal(inputString, color, delay) {
	$("#feedback-modal").find('p').html(inputString);
	$("#feedback-modal").css('background-color', color);
	$("#feedback-modal").slideToggle().slideDown();
	$("#feedback-modal").delay(delay).slideToggle().slideUp();
}