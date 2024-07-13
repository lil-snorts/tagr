package kiwi.tagr

import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication

@SpringBootApplication
class TagrApplication

fun main(args: Array<String>) {
	runApplication<TagrApplication>(*args)
}