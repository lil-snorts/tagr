package kiwi.tagr.components.services

import kiwi.tagr.model.ImageCreationFeedback
import java.awt.Image

interface ImageCreatorService {
    fun createNewImage(imageId: String, imageContent: String, chunk: Int): ImageCreationFeedback
}