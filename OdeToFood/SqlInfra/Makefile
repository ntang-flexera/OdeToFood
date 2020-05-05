SQLCONTAINER=mylocalsql
DOCKERSQLFILENAME=Dockerfile

run-sql-dev: ## Build the sql container and run it
	@docker stop $(SQLCONTAINER) || true
	@docker build -t $(SQLCONTAINER) -f $(DOCKERSQLFILENAME) .
	@docker run -e "ACCEPT_EULA=Y" -e SA_PASSWORD="P@ssw0rd" --net host -p 1433:1433 -d --rm --name $(SQLCONTAINER) $(SQLCONTAINER)


# SERVICENAME=device
# APINAME=data

# CONTAINERNAME=$(APINAME)api-container
# DEVCONTAINER=dev-container
# SQLCONTAINER=sql-container
# TESTCONTAINERNAME=postman/newman

# DEVDOCKERFILENAME=docker/Dockerfile-dev
# DOCKERFILENAME=docker/Dockerfile
# DOCKERSQLFILENAME=docker/Dockerfile-sql

# PHONY: help

# help:
# 	@awk 'BEGIN {FS = ":.*?## "} /^[a-zA-Z_-]+:.*?## / {printf "\033[36m%-30s\033[0m %s\n", $$1, $$2}' $(MAKEFILE_LIST)

# .DEFAULT_GOAL := help

# gen: clean ## Use goa to generate the boilerplate
# 	@goa gen github.com/flexera/fnms-data-api/data-api/design

# build-cli: gen ## Build the CLI
# 	@go build -o bin/cli ./cmd/$(APINAME)-cli

# build-server: gen ## build the server
# 	@./scripts/copy_pb.sh
# 	@go build -o bin/$(APINAME) ./cmd/$(APINAME)

# lint: ## run lint against codebase
# 	@golint ./...

# run-server: build-server ## run the server
# 	@./bin/$(APINAME)

# run-cli: build-cli ## Run the CLI with the supplied args
# ifdef ARGS
# 	@./bin/cli $(ARGS)
# else
# 	@echo ARGS are required
# endif

# build-docker: ## Build the docker container
# 	@docker stop $(CONTAINERNAME) || true
# 	@docker build -t $(CONTAINERNAME) -f $(DOCKERFILENAME) .

# run-docker: build-docker ## Build and run the docker container
# 	@docker stop $(CONTAINERNAME) || true
# 	@docker run -it -d --rm -p 8088:8088 $(CONTAINERNAME)

# clean: ## Remove bin and gen folders
# 	@rm -rf bin/ gen/

# test: ## Test the application
# 	@go test -v --cover ./... | grep -v /gen/

# run-docker-dev: run-sql-dev ## Build the container with the local volume attached for dev purposes
# 	@docker stop $(DEVCONTAINER) || true
# 	@docker build -t $(DEVCONTAINER) -f $(DEVDOCKERFILENAME) .
# 	@docker run -it --rm -p 8088:8088 --net host -v $(PWD):/app --env-file environment/.env $(DEVCONTAINER)

# build-sql-docker: ## Build the sql docker container
# 	@docker stop $(SQLCONTAINER) || true
# 	@docker build -t $(SQLCONTAINER) -f $(DOCKERSQLFILENAME) .

# run-sql-dev: ## Build the sql container and run it
# 	@docker stop $(SQLCONTAINER) || true
# 	@docker build -t $(SQLCONTAINER) -f $(DOCKERSQLFILENAME) .
# 	@docker run -e "ACCEPT_EULA=Y" -e SA_PASSWORD="P@ssw0rd" --net host -p 1433:1433 -d --rm --name $(SQLCONTAINER) $(SQLCONTAINER)

# push-docker-images: ## Build the docker container and push the images to the ECR for use in EKS
# 	@docker build -t testdataapi -f $(DOCKERFILENAME) .
# 	@docker tag testdataapi:latest 550466196064.dkr.ecr.us-east-2.amazonaws.com/testdataapi:1
# 	@docker push 550466196064.dkr.ecr.us-east-2.amazonaws.com/testdataapi:1
# 	@echo "Application image pushed successfully to ECR"
# 	@echo "Building SQL dev container image for testing"
# 	@docker build -t $(SQLCONTAINER):2 -f $(DOCKERSQLFILENAME) .
# 	@docker tag $(SQLCONTAINER):2 550466196064.dkr.ecr.us-east-2.amazonaws.com/testdataapi:2
# 	@docker push 550466196064.dkr.ecr.us-east-2.amazonaws.com/testdataapi:2
# 	@echo "SQL dev container image pushed successfully to ECR"
