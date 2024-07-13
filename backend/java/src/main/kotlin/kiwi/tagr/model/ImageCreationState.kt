package kiwi.tagr.model

enum class ImageCreationState(val message: String) {
    CREATED("Image created"),
    BUILDING("Image ready for more chunks"),
    FAILED("Critical error");
}