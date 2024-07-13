package kiwi.tagr.components.services.implementations

import kiwi.tagr.components.services.ImageCreatorService
import kiwi.tagr.model.ImageCreationFeedback
import org.springframework.stereotype.Service

@Service
class ImageCreatorServiceImpl: ImageCreatorService {
    override fun createNewImage(imageId: String, imageContent: String, chunk: Int): ImageCreationFeedback {
        TODO("Not yet implemented")
    }
}