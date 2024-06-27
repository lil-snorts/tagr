package kiwi.tagr.api

import kiwi.tagr.model.ImageUploadRequest
import org.springframework.http.ResponseEntity

class ImagesController : ImagesApi, ImageApi {

    override fun imageImageIdDelete(imageId: kotlin.String): ResponseEntity<Unit> {

        return ResponseEntity.ok().build();
    }

    override fun imagePost(imageUploadRequest: ImageUploadRequest?): ResponseEntity<Unit> {

    }
}