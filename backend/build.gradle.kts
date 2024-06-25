buildscript {
    repositories {
        mavenLocal()
        mavenCentral()
    }
    dependencies {
        classpath("org.openapitools:openapi-generator-gradle-plugin:5.6.0")
    }
}
apply(plugin = "org.openapi.generator")
plugins {
    id("org.springframework.boot") version "3.3.0"
    id("io.spring.dependency-management") version "1.1.5"
    id("org.openapi.generator") version "6.6.0"
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
    implementation("org.springframework.boot:spring-boot-starter")
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
        generatorName.set("kotlin")
        inputSpec.set("${rootDir}/../contract/contract.yaml")
        outputDir.set("${rootDir}/build/generated")
        apiPackage.set("org.openapi.example.api")
        invokerPackage.set("org.openapi.example.invoker")
        modelPackage.set("org.openapi.example.model")
        configOptions.set(mapOf("dateLibrary" to "java8"))
    }

    compileKotlin {
        dependsOn(openApiGenerate)
    }
}