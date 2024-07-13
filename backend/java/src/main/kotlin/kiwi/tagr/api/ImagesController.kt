package kiwi.tagr.api

import kiwi.tagr.components.services.ImageCreatorService
import kiwi.tagr.components.services.implementations.ImageCreatorServiceImpl
import kiwi.tagr.model.ImageUploadRequest
import lombok.AllArgsConstructor
import org.springframework.http.ResponseEntity
import java.util.*

@AllArgsConstructor
class ImagesController : ImagesApi, ImageApi {
    val imageCreatorService: ImageCreatorService = ImageCreatorServiceImpl();

    override fun imageImageIdDelete(imageId: kotlin.String): ResponseEntity<Unit> {

        return ResponseEntity.ok().build();
    }

    override fun imagePost(imageUploadRequest: ImageUploadRequest?): ResponseEntity<Unit> {
        imageCreatorService.createNewImage(UUID.randomUUID().toString(), imageUploadRequest!!.chunkContent, imageUploadRequest.chunkIndex.toInt())
        return ResponseEntity.ok().build();
    }
}