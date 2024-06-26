apply(plugin = "org.openapi.generator")
plugins {
    id("org.springframework.boot") version "3.3.0"
    id("io.spring.dependency-management") version "1.1.5"
    id("org.openapi.generator") version "7.6.0"
    kotlin("jvm") version "1.9.24"
    kotlin("plugin.spring") version "1.9.24"
}

group = "kiwi"
version = "0.0.1-SNAPSHOT"

java {
    toolchain {
        languageVersion.set(JavaLanguageVersion.of(21))
    }
}

configurations {
    compileOnly {
        extendsFrom(configurations.annotationProcessor.get())
    }
}

repositories {
    mavenLocal()
    mavenCentral()
}

dependencies {
    implementation(platform("org.springframework.boot:spring-boot-dependencies:3.3.1"))
    implementation("com.fasterxml.jackson.core:jackson-annotations:2.15.2")
    implementation("jakarta.servlet:jakarta.servlet-api:5.0.0")

    implementation("jakarta.validation:jakarta.validation-api:3.0.2")
    implementation("io.swagger.core.v3:swagger-annotations:2.2.10")
    implementation("org.springframework.boot:spring-boot-starter")
    implementation("org.springframework.boot:spring-boot-starter-web")
    implementation("org.springframework.boot:spring-boot-starter-webflux")
    implementation("org.springframework.boot:spring-boot-starter-json")
    implementation("org.jetbrains.kotlin:kotlin-reflect")
    implementation("org.jetbrains.kotlin:kotlin-stdlib-jdk8")
    implementation("com.squareup.moshi:moshi-kotlin:1.13.0")
    implementation("com.squareup.moshi:moshi-adapters:1.13.0")
    implementation("com.squareup.okhttp3:okhttp:4.10.0")
    compileOnly("org.projectlombok:lombok")
    annotationProcessor("org.projectlombok:lombok")
    testImplementation("io.kotlintest:kotlintest-runner-junit5:3.4.2")
    testImplementation("org.springframework.boot:spring-boot-starter-test")
    testImplementation("org.jetbrains.kotlin:kotlin-test-junit5")
    testRuntimeOnly("org.junit.platform:junit-platform-launcher")
}

kotlin {
    compilerOptions {
        freeCompilerArgs.addAll("-Xjsr305=strict")
    }
    sourceSets {
        main {
            kotlin.srcDir("${rootDir}/build/generated/src/main/kotlin")
        }
    }
}

tasks {
    withType<Test> {
        useJUnitPlatform()
    }

    // OpenAPI Generator configuration block
    openApiGenerate {
        generatorName.set("kotlin-spring")
        inputSpec.set("${rootDir}/../contract/contract.yaml")
        outputDir.set("${rootDir}/build/generated")
        apiPackage.set("kiwi.tagr.api")
        invokerPackage.set("kiwi.tagr.invoker")
        modelPackage.set("kiwi.tagr.model")
        configOptions.set(mapOf(
            "library" to "spring-boot",
            "useSpringBoot3" to "true",
            "dateLibrary" to "java8",
            "interfaceOnly" to "true",
            "documentationProvider" to "none",
        ))
    }

    compileKotlin {
        dependsOn(openApiGenerate)
    }
}