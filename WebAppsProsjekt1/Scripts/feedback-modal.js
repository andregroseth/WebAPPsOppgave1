function showFeedbackModal(inputString, color) {
	$("#feedback-modal").find('p').html(inputString);
	$("#feedback-modal").css('background-color', color);
	$("#feedback-modal").slideToggle().slideDown();
	$("#feedback-modal").delay(4000).slideToggle().slideUp();
}